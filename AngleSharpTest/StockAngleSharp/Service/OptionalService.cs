using CrawlerDAL.DTOs;
using Repository;
using Repository.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
{
    public class OptionalService
    {
        AngleSharpEntities db;
        OptionalRepository OR;
        public OptionalService()
        {
            db = new AngleSharpEntities();
            OR = new OptionalRepository();
        }
        public OptionalDTO GetOptionalStatus(string stock_id, int user_id)
        {
            return new OptionalDTO()
            {
                Stock_ID = stock_id,
                OptionalStatus = Convert.ToBoolean(OR.Get(x => x.Stock_ID == stock_id
                                                                            && x.User_ID == user_id).Status),
            };
        }
        public bool SelectOptional(string stock_id, int user_id)
        {
            var result = true;
            //判斷 是否新增過
            var Data = GetOptional(stock_id, user_id);
            if (Data != null)
            {
                result = this.UpdateOptional(Data);
            }
            else
            {
                this.AddOptional(stock_id, user_id);
            }
            return result;
        }
        public T_Optional GetOptional(string stock_id, int user_id)
        {
            return OR.Get(x => x.Stock_ID == stock_id && x.User_ID == user_id);
        }
        private void AddOptional(string stock_id, int user_id)
        {
            OR.Create(new T_Optional()
            {
                Stock_ID = stock_id,
                User_ID = user_id,
                Status = 1,
                AlterDate = DateTime.Now,
                CreatDate = DateTime.Now
            });
            OR.SaveChanges();
        }
        private bool UpdateOptional(T_Optional Data)
        {
            var result = (Data.Status == 0) ? 1 : 0;
            Data.Status = result;
            Data.AlterDate = DateTime.Now;
            OR.SaveChanges();
            return Convert.ToBoolean(result);
        }
    }
}
