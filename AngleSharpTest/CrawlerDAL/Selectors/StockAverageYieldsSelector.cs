using CrawlerDAL.Interfaces;
using CrawlerDAL.Models;
using CrawlerDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Selectors
{
    public class StockAverageYieldsSelector : YearModel<Yield>
    {
        public StockAverageYieldsSelector() { Years = new List<Yield>(); }

    }
}
