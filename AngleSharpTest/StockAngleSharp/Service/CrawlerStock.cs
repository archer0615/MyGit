using AngleSharp;
using AngleSharp.Dom;
using StockAngleSharp.Enums;
using StockAngleSharp.Extension;
using StockAngleSharp.Models;
using StockAngleSharp.URL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
{
    public class CrawlerStock
    {
        private const string yahooStockURL = CrawlerURL.yahooStockURL;
        private const string categoryURL = CrawlerURL.categoryURL;
        private IConfiguration config = Configuration.Default.WithDefaultLoader();

        //public StockViewModel GetStockById(int id)
        //{
        //    var URL_Id = id.ToString().PadLeft(4, '0');
        //    StockViewModel stockVM = new StockViewModel() { StockID = URL_Id };

        //    string URL = "q/q?s=" + URL_Id;
        //    var dom = BrowsingContext.New(config).OpenAsync(yahooStockURL + URL).Result;

        //    #region Hide
        //    var mainSelector = @"center > table:nth-child(9) > tbody > tr > td > table > tbody > tr:nth-child(2) > ";

        //    StockSelector stock = new StockSelector()
        //    {
        //        StockName = mainSelector + "td:nth-child(1) > a:nth-child(1)",
        //        StockTime = mainSelector + "td:nth-child(2)",
        //        StockDeal = mainSelector + "td:nth-child(3)",
        //        StockBuy = mainSelector + "td:nth-child(4)",
        //        StockSell = mainSelector + "td:nth-child(5)",
        //        StockGainDrop = mainSelector + "td:nth-child(6) > font",
        //        StockShareCount = mainSelector + "td:nth-child(7)",
        //        StockYesterday = mainSelector + "td:nth-child(8)",
        //        StockOpen = mainSelector + "td:nth-child(9)",
        //        StockTop = mainSelector + "td:nth-child(10)",
        //        StockDown = mainSelector + "td:nth-child(11)",
        //    };

        //    //判斷是否有此股票
        //    var page = dom.QuerySelector(stock.StockName);

        //    if (page == null) return null;

        //    var newStockProp = (from x in TypeDescriptor.GetProperties(stock).Cast<PropertyDescriptor>()
        //                        where x.Name != "StockID"
        //                        select x);

        //    var setStockProp = (from x in TypeDescriptor.GetProperties(stockVM).Cast<PropertyDescriptor>()
        //                        where x.Name != "StockID"
        //                        select x);

        //    foreach (var prop in newStockProp)
        //    {
        //        var selectorString = prop.GetValue(stock).ToString();
        //        var data = (Object)dom.QuerySelectorAll(selectorString)
        //                        .Select(x => x.TextContent).FirstOrDefault().Replace("\n", "").Replace(URL_Id, "");

        //        foreach (var item in setStockProp)
        //        {
        //            if (prop.Name == item.Name)
        //            {
        //                if (item.Name == "StockGainDrop")
        //                    data = (Object)data.ToString();

        //                PropertyInfo p = stockVM.GetType().GetProperty(item.Name);
        //                p.SetValue(stockVM, data);
        //            }
        //        }
        //    }

        //    #endregion

        //    return stockVM;
        //}

    }
}
