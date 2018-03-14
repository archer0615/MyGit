using CrawlerDAL.Interfaces;
using CrawlerDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Selectors
{
    public class SelectorModel : ISelector
    {
        public string mainSelector
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
    public class StockJuristicSelector : Day5Model<Juristic>
    {
        public StockJuristicSelector() { Days = new List<Juristic>(); }
    }
    public class Stock5DayGainDropSelector : Day5Model<GainDrop>
    {
        public Stock5DayGainDropSelector() { Days = new List<GainDrop>(); }
    }
    public class StockYieldsSelector : YearModel<Yield>
    {
        public StockYieldsSelector() { Years = new List<Yield>(); }
    }
}
