using CrawlerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.ViewModels
{
    public class AverageYieldViewModel : YearModel<AverageYield>
    {
        public AverageYieldViewModel() { Years = new List<AverageYield>(); }
    }
}
