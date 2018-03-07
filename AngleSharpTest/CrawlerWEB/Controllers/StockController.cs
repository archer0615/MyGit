using CrawlerWEB.Services;
using CrawlerWEB.ViewModels;
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
        public ActionResult StockPriceNow(string stock_id = "2002")
        {
            StockService ss = new StockService();
            var data = ss.GetStockPriceNow(stock_id);
            if (data.Contains("△"))
                data = $"<label style='color:Red'>{data}</laebl>";
            else if (data.Contains("▽"))
                data = $"<label style='color:Green'>{data}</laebl>";
            else
                data = $"<label>{data}</laebl>";
            return Content(data);
        }
        public async Task<ActionResult> StockPriceNowAsync(string stock_id = "2002")
        {
            StockService ss = new StockService();
            var data = await ss.GetStockPriceNowAsync(stock_id);
            StockNowPriceViewModel vm = new StockNowPriceViewModel() {
                Price = data,
            };
            if (data.Contains("△"))
                //$"<label class='Price' style='color:Red'>{data}</laebl>";
                vm.Color = "Red";
            else if (data.Contains("▽"))
                //data = $"<label class='Price' style='color:Green'>{data}</laebl>";
                vm.Color = "Green";
            else
                vm.Color = "Balck";
                //data = $"<label class='Price' >{data}</laebl>";
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Company_AjaxParital(string stock_Id = "2002")
        {
            StockService ss = new StockService();
            var data = ss.GetCompanyById(stock_Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}