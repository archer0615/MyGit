using CrawlerDAL.Selectors;
using StockAngleSharp.CheckService;
using StockAngleSharp.Facades;
using StockAngleSharp.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //YieldsService Ys = new YieldsService();
                //Ys.GetYieldsByStockId("2002");
            }
            catch (Exception ex)
            {

                throw;
            }
            //try
            //{
            //    T_StockService ts = new T_StockService();
            //    var vm = ts.GetStockYields5Year("2002");
            //    foreach (var item in vm.Result.Years)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }

    }
}
