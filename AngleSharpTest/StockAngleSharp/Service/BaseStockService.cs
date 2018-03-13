using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
{
    public abstract class BaseStockService
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
        public const string categoryURL = @"https://tw.stock.yahoo.com/h/kimosel.php?";
        public const string stockURL = @"https://tw.stock.yahoo.com/q/q?s=";

        public const string JuristicURL = @"https://www.cnyes.com/twstock/Institutional/";
        public const string stock5DayGainDrop = @"https://www.cnyes.com/twstock/ps_historyprice/";
        public string stockYieldsURL(string stock_id)
        {
            return $"https://www.wantgoo.com/stock/report/value?stockno={stock_id}&types=3";
        }
        public IConfiguration config = Configuration.Default.WithDefaultLoader();
        
    }
}
