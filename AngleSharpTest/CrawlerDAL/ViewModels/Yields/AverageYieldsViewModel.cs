using CrawlerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.ViewModels.Yields
{
    public class AverageYieldsViewModel
    {
        public string Year { get; set; }
        public string AverageRate { get; set; }
        public string AveragePrice { get; set; }
    }
}
