using StockAngleSharp.Models.DB;
using StockAngleSharp.Models.Repositorys;
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
