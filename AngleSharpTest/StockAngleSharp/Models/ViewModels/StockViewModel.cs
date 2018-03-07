using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Models.ViewModels
{
    public class StockViewModel
    {
        public string StockID { get; set; }
        public string StockName { get; set; }
        public string StockTime { get; set; }
        public string StockDeal { get; set; }
        public string StockBuy { get; set; }
        public string StockSell { get; set; }
        public string StockGainDrop { get; set; }
        public string StockShareCount { get; set; }
        public string StockYesterday { get; set; }
        public string StockOpen { get; set; }
        public string StockTop { get; set; }
        public string StockDown { get; set; }
    }
}
