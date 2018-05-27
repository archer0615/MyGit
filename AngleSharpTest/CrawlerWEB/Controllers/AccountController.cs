using StockAngleSharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrawlerWEB.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult MyOptional()
        {
            OptionalService OS = new OptionalService();
            var vm = OS.GetOptionalStatus(Convert.ToInt32(Session["UserId"]));
            return View(vm);
        }
    }
}