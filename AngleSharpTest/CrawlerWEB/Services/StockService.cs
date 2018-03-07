using CrawlerWEB.ViewModels;
using StockAngleSharp.Models.DB;
using StockAngleSharp.Models.Repositorys;
using StockAngleSharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CrawlerWEB.Services
{
    public class StockService
    {
        public StockCompanyViewModel GetCompanyById(string Stock_Id)
        {
            StockCompanyRepository rep = new StockCompanyRepository();
            var data = rep.Get(x => x.Stock_ID == Stock_Id);
            return ConvertToViewModel(data);
        }
        private StockCompanyViewModel ConvertToViewModel(T_StockCompany data)
        {
            CategoryRepository cr = new CategoryRepository();
            return new StockCompanyViewModel()
            {
                Stock_ID = data.Stock_ID,
                Catetory_Name = cr.Get(x => x.Catetory_ID == data.Catetory_ID).Catetory_Name,
                Company_Official_Url = data.Company_Official_Url,
                CompanyCreateDate = data.CompanyCreateDate,
                StockCreateDate = data.StockCreateDate,
                Stock_Capital = data.Stock_Capital,
                Revenue = data.Revenue,
                Company_Fatory = data.Company_Fatory
            };
        }
        public async Task<string> GetStockPriceNowAsync(string Stock_Id)
        {
            T_StockService s = new T_StockService();
            var stock = await s.GetStockPriceNowAsync(Stock_Id);
            return stock;
        }
        public string GetStockPriceNow(string Stock_Id)
        {
            T_StockService s = new T_StockService();
            var stock = s.GetStockPriceNow(Stock_Id);
            return stock;
        }
    }
}