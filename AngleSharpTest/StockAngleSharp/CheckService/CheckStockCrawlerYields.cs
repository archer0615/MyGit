using Repository;
using Repository.Repositorys;
using StockAngleSharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlerDAL.ViewModels;

namespace StockAngleSharp.CheckService
{
    public class CheckStockCrawlerYields
    {
        private YieldsRepository YR;
        private T_StockService TS;
        public CheckStockCrawlerYields()
        {
            YR = new YieldsRepository();
            TS = new T_StockService();
        }

        public List<T_Yields> CheckYields(string stock_id)
        {
            try
            {
                //取得DB資料 
                var dbDataList = YR.GetAllById(x => x.Stock_ID == stock_id);
                //網路資料
                var crawlerDataList = TS.GetStockAllYields(stock_id);
                //資料轉換
                var converted = this.ConvertCrawlerModelToDbModel(crawlerDataList, stock_id);
                //判斷重複的資料
                var exceptList = converted.Except(dbDataList, new CheckComparer()).ToList();

                return exceptList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<T_Yields> ConvertCrawlerModelToDbModel(StockYieldsViewModel crawlerDataList, string stock_id)
        {
            try
            {
                List<T_Yields> results = new List<T_Yields>();
                foreach (var item in crawlerDataList.Months)
                {
                    results.Add(new T_Yields()
                    {
                        Stock_ID = stock_id,
                        YearMonth = Convert.ToDateTime(item.YieldYear).ToString("yyyy/MM"),
                        MonthPrice = !string.IsNullOrWhiteSpace(item.MonthPrice) ? Convert.ToDouble(item.MonthPrice) : 0.0,
                        MonthRate = !string.IsNullOrWhiteSpace(item.YieldRate) ? Convert.ToDouble(item.YieldRate) : 0.0,
                    });
                }
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }
        private class CheckComparer : IEqualityComparer<T_Yields>
        {
            public bool Equals(T_Yields x, T_Yields y)
            {
                return x.YearMonth.Equals(y.YearMonth);
            }

            public int GetHashCode(T_Yields obj)
            {
                return obj.YearMonth.GetHashCode();
            }
        }
    }
}
