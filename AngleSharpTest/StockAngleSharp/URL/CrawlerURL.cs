﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.URL
{
    public static class CrawlerURL
    {
        #region StockURL

        //代號直接搜尋
        //https://tw.stock.yahoo.com/q/q?s=2311

        //選擇單一個股
        //https://tw.stock.yahoo.com/h/kimosel.php?form=menu&form_id=stock_id&form_name=stock_name

        //選擇類別
        //https://tw.stock.yahoo.com/h/kimosel.php?tse=1&cat=%E6%B0%B4%E6%B3%A5&form=menu&form_id=stock_id&form_name=stock_name&domain=0

        #endregion
        public const string yahooStockURL = @"https://tw.stock.yahoo.com/";
    }
}