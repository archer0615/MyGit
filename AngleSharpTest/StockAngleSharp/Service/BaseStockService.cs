using AngleSharp;
using StockAngleSharp.URL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
{
    public abstract class BaseStockService
    {
        public const string yahooStockURL = CrawlerURL.yahooStockURL;
        public const string stockURL = CrawlerURL.stockURL;
        public const string categoryURL = CrawlerURL.categoryURL;
        public IConfiguration config = Configuration.Default.WithDefaultLoader();
    }
}
