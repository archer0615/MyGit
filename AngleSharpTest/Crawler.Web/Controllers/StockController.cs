using StockAngleSharp.Service;
using StockAngleSharp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Crawler.Web.Controllers
{
    public class StockController : Controller
    {
        public ActionResult Index()
        {
            CrawlerStock crawlerStock = new CrawlerStock();
            List<StockViewModel> vm = new List<StockViewModel>();

            var task1 = Task.Factory.StartNew(() =>
           {
               //vm = crawlerStock.GetStockById();
           });
            task1.Wait();
            return View(vm);
        }
    }
}