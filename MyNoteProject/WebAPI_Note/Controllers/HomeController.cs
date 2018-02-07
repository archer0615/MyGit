using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI_Note.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            GetResponse();
            return View();
        }

        private HttpResponseBase GetResponse()
        {
            Response.Headers.Remove("Access-Control-Allow-Origin");
            Response.AddHeader("Access-Control-Allow-Origin", Request.UrlReferrer.GetLeftPart(UriPartial.Authority));

            Response.Headers.Remove("Access-Control-Allow-Credentials");
            Response.AddHeader("Access-Control-Allow-Credentials", "true");

            Response.Headers.Remove("Access-Control-Allow-Methods");
            Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");

            return Response;
        }
    }
}
