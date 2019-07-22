using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.Stock
{
    public class StockViewModel
    {
        [DisplayName("代號")]
        public string StockID { get; set; }
        [DisplayName("名稱")]
        public string StockName { get; set; }
        [DisplayName("時間")]
        public string StockTime { get; set; }
        [DisplayName("成交")]
        public string StockDeal { get; set; }
        [DisplayName("買進")]
        public string StockBuy { get; set; }
        [DisplayName("賣出")]
        public string StockSell { get; set; }
        [DisplayName("時間")]
        public string StockGainDrop { get; set; }
        [DisplayName("張數")]
        public string StockShareCount { get; set; }
        [DisplayName("昨收")]
        public string StockYesterday { get; set; }
        [DisplayName("開盤")]
        public string StockOpen { get; set; }
        [DisplayName("今日最高")]
        public string StockTop { get; set; }
        [DisplayName("今日最低")]
        public string StockDown { get; set; }

        public override string ToString()
        {
            return $"{this.StockName}  {this.StockBuy}";
        }
    }    
}
