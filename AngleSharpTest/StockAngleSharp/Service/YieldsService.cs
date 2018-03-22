using System;
using System.Collections.Generic;
using Repository.Repositorys;
using Repository;
using StockAngleSharp.Service;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlerDAL.ViewModels.Yields;

namespace StockAngleSharp.Service
{
    public class YieldsService
    {
        private YieldsRepository YR;
        private AngleSharpEntities db;
        public YieldsService()
        {
            db = new AngleSharpEntities();
            YR = new YieldsRepository();
        }
        public List<AverageYieldsViewModel> GetYieldsByStockId(string stock_id)
        {
            var reuslts = db.VW_AverageYields
                            .Where(x => x.Stock_ID == stock_id)
                            .Select(x => new AverageYieldsViewModel
                            {
                                Year = x.Year,
                                AveragePrice = x.AveragePrice.ToString(),
                                AverageRate = x.AverageRate.ToString()
                            }).OrderByDescending(x=>x.Year).ToList();
            return reuslts;
        }
    }
}
