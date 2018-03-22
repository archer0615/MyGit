using CrawlerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Selectors
{
    public class StockYieldsSelector : MonthModel<Yield>
    {
        public StockYieldsSelector()
        {
            Months = new List<Yield>();
        }
    }
}
