using AngularMvcWeb.Extensions.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AngularMvcWeb.Services
{
    public class BaseService
    {
        protected string generalDateFormat = "yyyy/MM/dd";

        public IQueryable<T> DataPaging<T>(IQueryable<T> data, Paging paging)
        {
            paging.TotalRecords = data.Count();
            var result = data.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
            return result;
        }
        public IEnumerable<T> DataPaging<T>(IEnumerable<T> data, Paging paging)
        {
            paging.TotalRecords = data.Count();
            var result = data.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
            return result;
        }
        protected Tuple<string, SqlParameter[]> getPropParameters<T>(T model, bool inclNullValParam = false, string[] exclPropNames = null) where T : class
        {
            List<SqlParameter> spParams = new List<SqlParameter>();
            string paramList = "";
            var properties = model.GetType().GetProperties();
            if (exclPropNames != null)
                properties = properties.Where(x => !exclPropNames.Contains(x.Name)).ToArray();
            foreach (var pi in properties)
            {
                string pn = string.Format("@{0}", pi.Name);
                var pv = pi.GetValue(model, null);
                if (inclNullValParam || pv != null)
                {
                    paramList += paramList == "" ? pn : string.Format(", {0}", pn);
                    spParams.Add(new SqlParameter(pn, pv ?? DBNull.Value));
                }
            }
            return Tuple.Create(paramList, spParams.ToArray());
        }
    }
}