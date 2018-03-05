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
    }
}
