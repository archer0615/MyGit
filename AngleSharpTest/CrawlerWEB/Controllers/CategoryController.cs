//using CrawlerWEB.Services;
using CrawlerWEB.Common;
using StockAngleSharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrawlerWEB.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult _CategoryListPartial()
        {
            CategoryService categoryService = new CategoryService();
            var dataList = categoryService.GetAllCategory();
            return PartialView(dataList);
        }
        [MyAuthorize]
        public ActionResult StockList(int Id = 1)
        {
            CategoryService categoryService = new CategoryService();
            var datas = categoryService.GetStockByCategory(Id);
            return View(datas);
        }
    }
}