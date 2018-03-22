using CrawlerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.ViewModels
{
    public class StockAverageYieldsViewModel : YearModel<Yield>
    {
        public StockAverageYieldsViewModel() { Years = new List<Yield>(); }
    }
}
