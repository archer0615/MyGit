using CrawlerDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Selectors
{
    public class StockCrawlerModel
    {

    }
    public class StockJuristicSelector : Day5Model<Juristic>
    {
        public StockJuristicSelector()
        {
            Days = new List<Juristic>();
        }
    }
    public class Stock5DayGainDropSelector : Day5Model<GainDrop>
    {
        public Stock5DayGainDropSelector()
        {
            Days = new List<GainDrop>();
        }
    }
}
