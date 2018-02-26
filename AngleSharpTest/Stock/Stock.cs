using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    class Stock
    {
        #region URL

        //代號直接搜尋
        //https://tw.stock.yahoo.com/q/q?s=2311

        //選擇單一個股
        //https://tw.stock.yahoo.com/h/kimosel.php?form=menu&form_id=stock_id&form_name=stock_name

        //選擇類別
        //https://tw.stock.yahoo.com/h/kimosel.php?tse=1&cat=%E6%B0%B4%E6%B3%A5&form=menu&form_id=stock_id&form_name=stock_name&domain=0

        #endregion

        private string yahooStockURL;

        public Stock()
        {
            yahooStockURL = @"https://tw.stock.yahoo.com/";
        }

        public void GetStockByCategory()
        {
            //選擇類別
            string categoryURL = @"https://tw.stock.yahoo.com/h/kimosel.php" + "?tse=1&cat=%E6%B0%B4%E6%B3%A5&" + "form=menu&form_id=stock_id&form_name=stock_name&domain=0";

        }

        public void GetStockById(int id)
        {
            yahooStockURL += "q/q?s=" + id.ToString();

            var config = Configuration.Default.WithDefaultLoader();

            var dom = BrowsingContext.New(config).OpenAsync(yahooStockURL).Result;

            var stockName = string.Empty;

            string timeStamp = (DateTime.Now.AddHours(8) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds.ToString();

            timeStamp = timeStamp.Substring(0, timeStamp.IndexOf('.'));

            //var page = dom.QuerySelector("center > table:nth-child(13) > tbody > tr > td > table");

            //if (page == null) return;

            var stockNameSelector = "center > table:nth-child(9) > tbody > tr > td > table > tbody > tr:nth-child(2) > td:nth-child(1) > a:nth-child(1)";
            stockName = dom.QuerySelectorAll(stockNameSelector).Select(x => x.TextContent).FirstOrDefault();

            Console.WriteLine(stockName);
        }
    }
}
