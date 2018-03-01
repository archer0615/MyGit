using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.Reflection2_SQL
{
    public class ReflectionProgram : IProcess   
    {
        public void RunMain()
        {
            //使用方式
            ViewModel model = new ViewModel
            {
                ID = 1,
                Name = "Name",
                Address = "Address",
                Phone = "12345678"
            };
            var spParams = getPropParameters(model);
            //var result = db.Database
            //    .ExecuteSqlCommand($"EXEC SP_Name {spParams.Item1}", spParams.Item2);
        }

        public class ViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
        }

        protected static Tuple<string, SqlParameter[]> getPropParameters<T>(T model, bool inclNullValParam = false, string[] exclPropNames = null) where T : class
        {
            List<SqlParameter> spParams = new List<SqlParameter>();
            string paramList = "";
            //取得所有屬性
            var properties = model.GetType().GetProperties();
            if (exclPropNames != null)
                //將所有屬性的名稱裝入Array
                properties = properties.Where(x => !exclPropNames.Contains(x.Name)).ToArray();
            //各別裝值
            foreach (var pi in properties)
            {
                string pn = $"@{pi.Name}";
                var pv = pi.GetValue(model, null);
                if (inclNullValParam || pv != null)
                {
                    paramList += paramList == "" ? pn : $", {pn}";
                    spParams.Add(new SqlParameter(pn, pv ?? DBNull.Value));
                }
            }
            return Tuple.Create(paramList, spParams.ToArray());
        }
    }
}
