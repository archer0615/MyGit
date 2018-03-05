using CrawlerWEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrawlerWEB.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            CategoryService categoryService = new CategoryService();
            var dataList = categoryService.GetAllCategory();
            return View(dataList);
        }
    }
}