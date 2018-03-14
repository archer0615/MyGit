using AngleSharp;
using CrawlerDAL.Interfaces;
using CrawlerDAL.Selectors;
using StockAngleSharp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
{
    public abstract class BaseCrawlerAsyncService<T> : BaseStockService
        where T : class
    {
        ISelector selector;
        string URL = string.Empty;
        string mainSelector = string.Empty;

        public BaseCrawlerAsyncService(string stock_id, CrawlerURL type)
        {
            switch (type)
            {
                case CrawlerURL.StockPriceNow:
                    URL = stockURL + stock_id;
                    mainSelector = @"center > table:nth-child(9) > tbody > tr > td > table > tbody > tr:nth-child(2) > ";
                    selector = new StockSelector(mainSelector);
                    break;
                case CrawlerURL.StockJuristic:
                    URL = JuristicURL + stock_id + ".htm";
                    mainSelector = @"#main3 > div.mbx.bd3 > div.tabvl > table > tbody > ";
                    //selector = new StockSelector();
                    break;
                case CrawlerURL.GainDrop5Day:
                    URL = stock5DayGainDrop + stock_id + ".htm";
                    mainSelector = @"#main3 > div.mbx.bd3 > div.tab > table > tbody > ";
                    //selector = new StockSelector();
                    break;
                case CrawlerURL.Yields5Year:
                    URL = stockYieldsURL(stock_id);
                    mainSelector = @"#mainCol > div.br-trl > table > tbody > ";
                    //selector = new StockSelector();
                    break;
            }
        }
        public async Task<T> GetDataWithAsync(T vm)
        {
            var dom = await BrowsingContext.New(config).OpenAsync(URL);

            var newStockProp = TypeDescriptor.GetProperties(selector).Cast<PropertyDescriptor>();
            var setStockProp = TypeDescriptor.GetProperties(vm).Cast<PropertyDescriptor>();

            foreach (var prop in newStockProp)
            {
                var selectorString = prop.GetValue(selector).ToString();
                var data = (Object)dom.QuerySelector(selectorString).TextContent ?? string.Empty;

                foreach (var item in setStockProp)
                {
                    if (prop.Name == item.Name)
                        vm.GetType().GetProperty(item.Name).SetValue(vm, data);
                }
            }
            return vm;
        }
    }
}
