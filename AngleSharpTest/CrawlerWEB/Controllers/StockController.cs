using CrawlerDAL.ViewModels;
using StockAngleSharp.Models.Repositorys;
using StockAngleSharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CrawlerWEB.Controllers
{
    public class StockController : Controller
    {
        public async Task<ActionResult> StockPriceNowAsync(string stock_id = "2002")
        {
            T_StockService s = new T_StockService();
            var vm = await s.GetStockPriceNowAsync(stock_id);
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> StockJuristicAsync(string stock_id = "2002")
        {
            T_StockService s = new T_StockService();
            var vm = await s.GetStockJuristicAsync(stock_id);
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> StockGainDrop5DayAsync(string stock_id)
        {
            T_StockService s = new T_StockService();
            var vm = await s.GetStockGainDrop5Day(stock_id);
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> StockYields5YearAsync(string stock_id)
        {
            T_StockService s = new T_StockService();
            var vm = await s.GetStockYields5Year(stock_id);
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Company_AjaxParital(string stock_Id = "2002")
        {
            T_StockService s = new T_StockService();
            var data = s.GetCompanyById(stock_Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}