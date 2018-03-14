using CrawlerDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Selectors
{
    public class StockSelector : ISelector
    {
        public string mainSelector { get; set; }

        public StockSelector(string _mainSelector)
        {
            mainSelector = _mainSelector;
        }
        /// <summary>
        /// 代號
        /// </summary>
        public string StockID { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 時間
        /// </summary>
        public string StockTime { get; set; }
        /// <summary>
        /// 成交
        /// </summary>
        public string StockDeal { get; set; }
        /// <summary>
        /// 買進
        /// </summary>
        public string StockBuy { get; set; }
        /// <summary>
        /// 賣出
        /// </summary>
        public string StockSell { get; set; }
        /// <summary>
        /// 漲跌
        /// </summary>
        public string StockGainDrop { get; set; }
        /// <summary>
        /// 張數
        /// </summary>
        public string StockShareCount { get; set; }
        /// <summary>
        /// 昨收
        /// </summary>
        public string StockYesterday { get; set; }
        /// <summary>
        /// 開盤
        /// </summary>
        public string StockOpen { get; set; }
        /// <summary>
        /// 今日最高
        /// </summary>
        public string StockTop { get; set; }
        /// <summary>
        /// 今日最低
        /// </summary>
        public string StockDown { get; set; }


    }

}
