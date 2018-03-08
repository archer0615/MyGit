using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerWEB.ViewModels
{
    public class StockViewModel
    {
        public string StockID { get; set; }
        public string StockName { get; set; }
        public string StockURL { get; set; }
        public int CategoryID { get; set; }
    }
    public class StockNowPriceViewModel
    {
        public string Price { get; set; }
        public string GainDrop { get; set; }
        public string Color { get; set; }
    }
}