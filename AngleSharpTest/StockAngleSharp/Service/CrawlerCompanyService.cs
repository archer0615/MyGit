using AngleSharp;
using CrawlerDAL.Selectors;
using CrawlerDAL.ViewModels;
using StockAngleSharp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
{
    public class CrawlerCompanyService : BaseStockService
    {
        public CompanyViewModel GetCompany(int category_Id, string stock_Id)
        {
            CompanyViewModel companyVm = new CompanyViewModel();
            //https://tw.stock.yahoo.com/d/s/company_1101.html
            string URL = $"{yahooStockURL}/d/s/company_{stock_Id}.html";

            var dom = BrowsingContext.New(config).OpenAsync(URL).Result;

            var mainSelector = @"table table tbody > ";

            CompanySelector company = new CompanySelector(mainSelector)
            {
                CompanyCreateDate = mainSelector + "tr:nth-child(3) > td:nth-child(2)",
                StockCreateDate = mainSelector + "tr:nth-child(4) > td:nth-child(2)",
                Stock_Capital = mainSelector + "tr:nth-child(8) > td:nth-child(2)",
                Revenue = mainSelector + "tr:nth-child(11) > td:nth-child(2)",
                Company_Official_Url = mainSelector + "tr:nth-child(12) > td:nth-child(2)",
                Company_Fatory = mainSelector + "tr:nth-child(13) > td:nth-child(2)"
            };
            var seclectorProps = TypeDescriptor.GetProperties(company).Cast<PropertyDescriptor>();
            var companyProps = TypeDescriptor.GetProperties(companyVm).Cast<PropertyDescriptor>();

            foreach (var sProp in seclectorProps)
            {
                var selectorString = sProp.GetValue(company).ToString();
                var test = dom.QuerySelectorAll(selectorString).Select(x => x.TextContent);
                if (test.Count() == 0) break;
                var data = (Object)dom.QuerySelectorAll(selectorString)
                                                    .Select(x => x.TextContent).FirstOrDefault()
                                                    .Replace("\n", "").Replace("        ", "");
                foreach (var cProp in companyProps)
                {
                    if (sProp.Name == cProp.Name)
                        companyVm.GetType().GetProperty(cProp.Name).SetValue(companyVm, data);
                }
            }
            return companyVm;
        }
    }
}
