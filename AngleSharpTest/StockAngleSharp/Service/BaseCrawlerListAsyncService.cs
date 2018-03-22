using AngleSharp;
using CrawlerDAL.Interfaces;
using CrawlerDAL.Selectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
{
    public abstract class BaseCrawlerListAsyncService<T> : BaseStockService
         where T : class
    {
        string URL = string.Empty;
        ISelectorList selectList;
        public BaseCrawlerListAsyncService(string stock_id, ISelectorList _selectorList)
        {
            selectList = _selectorList;
        }

        public async Task<T> GetDataWithAsync(T vm)
        {
            var dom = await BrowsingContext.New(config).OpenAsync(URL);


            //for (int i = 0; i < vm.Days.Count; i++)
            //{
            //    var newStockProp = TypeDescriptor.GetProperties(selector.Days[i]).Cast<PropertyDescriptor>();
            //    var setStockProp = TypeDescriptor.GetProperties(vm.Days[i]).Cast<PropertyDescriptor>();

            //    foreach (var prop in newStockProp)
            //    {
            //        var selectorString = prop.GetValue(selector.Days[i]).ToString();
            //        var data = (Object)dom.QuerySelector(selectorString).TextContent ?? "";

            //        foreach (var item in setStockProp)
            //        {
            //            if (prop.Name == item.Name)
            //                vm.Days[i].GetType().GetProperty(item.Name).SetValue(vm.Days[i], data);
            //        }
            //    }
            //}

            return vm;
        }
    }
}
