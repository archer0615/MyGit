using AngleSharp;
using StockAngleSharp.Enums;
using StockAngleSharp.Extension;
using StockAngleSharp.Models.DB;
using StockAngleSharp.Models.DTOs;
using System;
using System.Collections.Generic;
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
    }
}
