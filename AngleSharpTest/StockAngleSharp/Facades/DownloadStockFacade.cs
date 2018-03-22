using Repository;
using Repository.Repositorys;
using StockAngleSharp.CheckService;
using StockAngleSharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Facades
{
    public class DownloadStockFacade
    {
        /// <summary>
        /// 下載殖利率/平均月股價
        /// </summary>
        /// <param name="stock_id">非必填</param>
        public void DownloadYields(string stock_id = "")
        {
            try
            {
                CheckStockCrawlerYields CSCY = new CheckStockCrawlerYields();
                YieldsRepository YR = new YieldsRepository();
                StockRepository SR = new StockRepository();

                if (!string.IsNullOrWhiteSpace(stock_id))
                {
                    var addYields = CSCY.CheckYields(stock_id);
                }
                else
                {
                    var stockList = SR.GetAll();
                    foreach (var stock in stockList)
                    {
                        var tmp = YR.Get(x => x.Stock_ID == stock.Stock_ID);
                        if (tmp == null)
                        {
                            var addYields = CSCY.CheckYields(stock.Stock_ID);
                            Console.Write("目前進行至 :" + stock.Stock_ID);
                            if (addYields.Count > 0)
                            {
                                YR.CreateAll(addYields);
                                Console.WriteLine("\t新增 : " + addYields.Count + " 筆資料");
                            }
                            else
                            {
                                Console.WriteLine($"無新增資料");
                            }
                        }
                        else
                        {
                            Console.WriteLine("已取得資料 : "+stock.Stock_ID);
                        }
                    }
                }
                YR.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DownloadStock()
        {
            T_StockService s = new T_StockService();
            var stockList = s.GetAllStockCategory();
            StockRepository stockRepository = new StockRepository();
            stockRepository.CreateAll(stockList);
        }

        public void DownloadCompany()
        {
            CrawlerCompanyService s = new CrawlerCompanyService();

            StockRepository a = new StockRepository();
            StockCompanyRepository sc = new StockCompanyRepository();

            List<T_StockCompany> datas = new List<T_StockCompany>();
            var data = a.GetAll().Where(x => x.Stock_Catetory_ID > 1 && x.Stock_Catetory_ID < 28);
            foreach (var item in data)
            {
                var ddd = s.GetCompany(item.Stock_Catetory_ID, item.Stock_ID);
                datas.Add(new T_StockCompany()
                {
                    Stock_ID = item.Stock_ID,
                    Company_Url = item.Stock_Url,
                    Catetory_ID = item.Stock_Catetory_ID,
                    CompanyCreateDate = ddd.CompanyCreateDate,
                    StockCreateDate = ddd.StockCreateDate,
                    Stock_Capital = ddd.Stock_Capital,
                    Revenue = ddd.Revenue,
                    Company_Official_Url = ddd.Company_Official_Url,
                    Company_Fatory = ddd.Company_Fatory
                });
            }
            sc.CreateAll(datas);

        }

        public string DownloadStockNow(string stock_id)
        {
            T_StockService s = new T_StockService();
            var stock = s.GetStockPriceNow(stock_id);
            return stock;
        }
    }
}
