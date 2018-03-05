using AngleSharp;
using StockAngleSharp.Enums;
using StockAngleSharp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
{
    public class CrawlerStockCategoryService : BaseStockService
    {
        public List<T_CategoryModel> GetAllCategory()
        {
            string URL = $"{categoryURL}tse=1&cat=%A5b%BE%C9%C5%E9&form=menu&form_id=stock_id&form_name=stock_name&domain=0";

            var dom = BrowsingContext.New(config).OpenAsync(URL).Result;

            var cateList = dom.QuerySelectorAll("body > form > table:nth-child(3) > tbody > tr > td > table > tbody td[rowspan!='3'] a").Select(x => x.TextContent);

            List<T_CategoryModel> results = new List<T_CategoryModel>();

            var seq = 1;
            foreach (var item in cateList)
            {
                results.Add(new T_CategoryModel()
                {
                    Catetory_ID = seq++,
                    Catetory_Name = item,
                    Catetory_Se_ID = 1,
                });
            }

            return results;
        }
    }
}
