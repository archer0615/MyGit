using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerDAL.ViewModels
{
    public class StockViewModel
    {
        public string StockID { get; set; }
        public string StockName { get; set; }
        public string StockURL { get; set; }
        public int CategoryID { get; set; }
    }
}