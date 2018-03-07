using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerWEB.ViewModels
{
    public class CategoryStockViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<StockViewModel> StockList { get; set; }
    }
}