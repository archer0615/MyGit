using AngleSharp;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using AngleSharp.Xml;
using CrawlerDAL.Selectors;
using CrawlerDAL.ViewModels;
using StockAngleSharp.Enums;
using StockAngleSharp.Extension;
using StockAngleSharp.Models;
using StockAngleSharp.Models.DB;
using StockAngleSharp.Models.DTOs;
using StockAngleSharp.Models.Repositorys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
{
    public class T_StockService : BaseStockService
    {
        public List<T_Stock> GetAllStockCategory()
        {
            List<T_Stock> results = new List<T_Stock>();

            var cateList = Enum.GetNames(typeof(CityCategory));

            var cateSeq = 1;
            foreach (var cate in cateList)
            {
                string URL = $"{categoryURL}tse=1&cat={cate}&form=menu&form_id=stock_id&form_name=stock_name&domain=0";

                var dom = BrowsingContext.New(config).OpenAsync(URL).Result;

                var names = dom.QuerySelectorAll("body > form > form > table > tbody > tr > td > table > tbody a").Select(x => x.TextContent).ToList();

                foreach (var name in names)
                {
                    results.Add(new T_Stock()
                    {
                        Stock_ID = ReplaceOther.ReplaceEnterWord(name.Substring(0, name.IndexOf(' '))),
                        Stock_Name = name.Substring(name.IndexOf(' ') + 1),
                        Stock_Catetory_ID = cateSeq,
                        Stock_Url = stockURL + ReplaceOther.ReplaceEnterWord(name.Substring(0, name.IndexOf(' ')))
                    });
                }
                cateSeq++;
            }

            return results;
        }
        public string GetStockPriceNow(string stock_id)
        {
            string URL = stockURL + stock_id;
            var dom = BrowsingContext.New(config).OpenAsync(URL);// .Result;

            var selector = @"center > table:nth-child(9) > tbody > tr > td > table > tbody > tr:nth-child(2) > td:nth-child(6) > font";
            var data = dom.Result.QuerySelector(selector).TextContent ?? "";
            if (!string.IsNullOrWhiteSpace(data))
                data = data.Replace("\n", "").Trim();
            return data;
        }
        public async Task<StockNowPriceViewModel> GetStockPriceNowAsync(string stock_id)
        {
            StockNowPriceViewModel vm = new StockNowPriceViewModel();
            string URL = stockURL + stock_id;
            var dom = await BrowsingContext.New(config).OpenAsync(URL);// .Result;

            var mainSelector = @"center > table:nth-child(9) > tbody > tr > td > table > tbody > tr:nth-child(2) > ";

            StockSelector stock = new StockSelector()
            {
                StockDeal = mainSelector + "td:nth-child(3)",
                StockGainDrop = mainSelector + "td:nth-child(6) > font",
            };
            vm.Price = dom.QuerySelector(stock.StockDeal).TextContent ?? "";
            vm.GainDrop = dom.QuerySelector(stock.StockGainDrop).TextContent ?? "";
            if (!string.IsNullOrWhiteSpace(vm.GainDrop))
                vm.GainDrop = vm.GainDrop.Replace("\n", "").Trim();

            if (vm.GainDrop.Contains("△"))
                vm.Color = "Red";
            else if (vm.GainDrop.Contains("▽"))
                vm.Color = "Green";
            else
                vm.Color = "Balck";

            return vm;
        }

        public async Task<StockJuristicVeiwModel> GetStockJuristicAsync(string stock_id)
        {
            StockJuristicVeiwModel vm = new StockJuristicVeiwModel();
            StockJuristicSelector selector = new StockJuristicSelector();

            string URL = JuristicURL + stock_id + ".htm";

            var dom = await BrowsingContext.New(config).OpenAsync(URL);// .Result;

            var mainSelector = @"#main3 > div.mbx.bd3 > div.tabvl > table > tbody > ";

            var flg = 2;
            for (int tr = 0; tr < 5; tr++)
            {
                selector.Days.Add(new Juristic());
                vm.Days.Add(new Juristic());

                selector.Days[tr].JuristicDate = mainSelector + $"tr:nth-child({tr + flg}) > td:nth-child(1)";
                selector.Days[tr].Foreign = mainSelector + $"tr:nth-child({tr + flg}) > td:nth-child(2)";
                selector.Days[tr].Investment = mainSelector + $"tr:nth-child({tr + flg}) > td:nth-child(3)";
                selector.Days[tr].Self = mainSelector + $"tr:nth-child({tr + flg}) > td:nth-child(4)";
                selector.Days[tr].Total = mainSelector + $"tr:nth-child({tr + flg}) > td:nth-child(5)";
            }

            for (int i = 0; i < vm.Days.Count; i++)
            {
                var newStockProp = TypeDescriptor.GetProperties(selector.Days[i]).Cast<PropertyDescriptor>();
                var setStockProp = TypeDescriptor.GetProperties(vm.Days[i]).Cast<PropertyDescriptor>();

                foreach (var prop in newStockProp)
                {
                    var selectorString = prop.GetValue(selector.Days[i]).ToString();
                    var data = (Object)dom.QuerySelector(selectorString).TextContent ?? "";

                    foreach (var item in setStockProp)
                    {
                        if (prop.Name == item.Name)
                            vm.Days[i].GetType().GetProperty(item.Name).SetValue(vm.Days[i], data);
                    }
                }
            }

            return vm;
        }

        public async Task<Stock5DayGainDropViewModel> GetStockGainDrop5Day(string stock_id)
        {
            Stock5DayGainDropViewModel vm = new Stock5DayGainDropViewModel();
            Stock5DayGainDropSelector selector = new Stock5DayGainDropSelector();

            string URL = stock5DayGainDrop + stock_id + ".htm";

            var dom = await BrowsingContext.New(config).OpenAsync(URL);

            var mainSelector = @"#main3 > div.mbx.bd3 > div.tab > table > tbody > ";

            var flg = 2;
            for (int tr = 0; tr < 5; tr++)
            {
                selector.Days.Add(new GainDrop());
                vm.Days.Add(new GainDrop());
                selector.Days[tr].GainDropDate = mainSelector + $"tr:nth-child({tr + flg}) > td:nth-child(1)";
                selector.Days[tr].Per = mainSelector + $"tr:nth-child({tr + flg}) > td:nth-child(7)";
            }

            for (int i = 0; i < vm.Days.Count; i++)
            {
                var newStockProp = TypeDescriptor.GetProperties(selector.Days[i]).Cast<PropertyDescriptor>();
                var setStockProp = TypeDescriptor.GetProperties(vm.Days[i]).Cast<PropertyDescriptor>();

                foreach (var prop in newStockProp)
                {
                    var selectorString = prop.GetValue(selector.Days[i]).ToString();
                    var data = (Object)dom.QuerySelector(selectorString).TextContent ?? "";

                    foreach (var item in setStockProp)
                    {
                        if (prop.Name == item.Name)
                            vm.Days[i].GetType().GetProperty(item.Name).SetValue(vm.Days[i], data);
                    }
                }
            }

            return vm;
        }

        public async Task<AverageYieldViewModel> GetStockYields5Year(string stock_id)
        {
            //計算年數參數
            var calcYear = 5;
            var flg = 1;
            AverageYieldViewModel TrueVm = new AverageYieldViewModel();

            StockYieldsViewModel vm = new StockYieldsViewModel();
            StockYieldsSelector selector = new StockYieldsSelector();

            var URL = this.stockYieldsURL(stock_id);

            var dom = await BrowsingContext.New(config).OpenAsync(URL);

            var mainSelector = @"#mainCol > div.br-trl > table > tbody > ";

            DateTime Now = DateTime.Now;

            var indexMonth = Now.Month;

            var trCount = 0;

            var stopYear = Now.Year - calcYear;
            for (int i = Now.Year; i >= stopYear; i--)
            {
                for (int j = indexMonth; j > 0; j--)
                {
                    trCount++;
                }
                indexMonth = 12;
            }

            for (int tr = 0; tr < trCount; tr++)
            {
                selector.Years.Add(new Yield());
                vm.Years.Add(new Yield());

                selector.Years[tr].YieldYear = mainSelector + $"tr:nth-child({tr + flg}) > td:nth-child(1)";
                selector.Years[tr].YieldRate = mainSelector + $"tr:nth-child({tr + flg}) > td:nth-child(2)";
                selector.Years[tr].MonthPrice = mainSelector + $"tr:nth-child({tr + flg}) > td:nth-child(3)";
            }

            for (int i = 0; i < vm.Years.Count; i++)
            {
                var newStockProp = TypeDescriptor.GetProperties(selector.Years[i]).Cast<PropertyDescriptor>();
                var setStockProp = TypeDescriptor.GetProperties(vm.Years[i]).Cast<PropertyDescriptor>();
                foreach (var prop in newStockProp)
                {
                    var selectorString = prop.GetValue(selector.Years[i]).ToString();
                    var data = (Object)dom.QuerySelector(selectorString).TextContent ?? "";

                    foreach (var item in setStockProp)
                    {
                        if (prop.Name == item.Name)
                            vm.Years[i].GetType().GetProperty(item.Name).SetValue(vm.Years[i], data);
                    }
                }
            }

            var tmp = 0;
            for (int year = Now.Year; year > Now.Year - calcYear; year--)
            {
                var dataList = vm.Years.Where(x => x.YieldYear.Substring(0, 4) == year.ToString()).ToList();
                TrueVm.Years.Add(new AverageYield() { Year = year.ToString() });
                for (int i = 0; i < dataList.Count(); i++)
                {
                    TrueVm.Years[tmp].Price.Add(Convert.ToDouble(dataList[i].MonthPrice));
                    TrueVm.Years[tmp].Rate.Add(Convert.ToDouble(dataList[i].YieldRate));
                }
                tmp++;
            }

            return TrueVm;
        }

        public StockCompanyViewModel GetCompanyById(string Stock_Id)
        {
            StockCompanyRepository rep = new StockCompanyRepository();
            var data = rep.Get(x => x.Stock_ID == Stock_Id);
            return ConvertToViewModel(data);
        }
        private StockCompanyViewModel ConvertToViewModel(T_StockCompany data)
        {
            CategoryRepository cr = new CategoryRepository();
            return new StockCompanyViewModel()
            {
                Stock_ID = data.Stock_ID,
                Catetory_Name = cr.Get(x => x.Catetory_ID == data.Catetory_ID).Catetory_Name,
                Company_Official_Url = data.Company_Official_Url,
                CompanyCreateDate = data.CompanyCreateDate,
                StockCreateDate = data.StockCreateDate,
                Stock_Capital = data.Stock_Capital,
                Revenue = data.Revenue,
                Company_Fatory = data.Company_Fatory
            };
        }
    }
}
