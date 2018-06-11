using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using C_SharpNote.Compare;
using C_SharpNote.EnumHelper;
using C_SharpNote.HashPassword;
using C_SharpNote.DateTimeHelper;
using C_SharpNote.Helper;
using AngleSharp;

namespace C_SharpNote
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public async void Task1()
        {
            //DoGet(50, 100);
            var start = 50;
            var end = 100;
            for (int i = start; i < end; i++)
            {
                var datas = await GetStockById(i);
                if (datas != null) Console.WriteLine(datas.ToString());
            }
        }
        public async void Task2()
        {
            var start = 2002;
            var end = 2035;
            //DoGet(100, 150);
            for (int i = start; i < end; i++)
            {
                var datas = await GetStockById(i);
                if (datas != null) Console.WriteLine(datas.ToString());
            }
        }
        public async void Task3()
        {
            var start = 2301;
            var end = 2350;
            //DoGet(150, 200);
            for (int i = start; i < end; i++)
            {
                var datas = await GetStockById(i);
                if (datas != null) Console.WriteLine(datas.ToString());
            }
        }
        public async void DoGet(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                var datas = await GetStockById(i);
                if (datas != null) Console.WriteLine(datas.ToString());
            }
        }
        public const string yahooStockURL = @"https://tw.stock.yahoo.com/";

        public async Task<StockViewModel> GetStockById(int id)
        {
            var URL_Id = id.ToString().PadLeft(4, '0');

            var config = Configuration.Default.WithDefaultLoader();
            string address = "q/q?s=" + URL_Id;

            var dom = await BrowsingContext.New(config).OpenAsync(yahooStockURL + address);

            var mainSelector = @"center > table:nth-child(9) > tbody > tr > td > table > tbody > tr:nth-child(2) > ";

            var cellSelector = mainSelector + "td:nth-child(1) > a:nth-child(1)";

            StockSelector stock = new StockSelector()
            {
                StockName = mainSelector + "td:nth-child(1) > a:nth-child(1)",
                StockBuy = mainSelector + "td:nth-child(4)",
            };

            //判斷是否有此股票
            var page = dom.QuerySelector(cellSelector);

            if (page == null) return null;

            var name = page.TextContent;
            var buy = dom.QuerySelector(stock.StockBuy).TextContent;
            StockViewModel stockViewModel = new StockViewModel()
            {
                StockName = name,
                StockBuy = buy,
            };
            return stockViewModel;
        }

    }
}
