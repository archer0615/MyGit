using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace C_SharpNote.AttributeHelper
{
    /// <summary>
    /// 處理Seesion過期 並導頁至登入頁
    /// </summary>
    public class CheckSessionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext httpcontext = HttpContext.Current;
            if (httpcontext.Session != null)
            {
                if (httpcontext.Session.IsNewSession)
                {
                    string sessioncookie = httpcontext.Request.Headers["Cookie"];
                    if ((sessioncookie != null) && (sessioncookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        //導頁
                        Logon(filterContext);
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }
        private void Logon(ActionExecutingContext filterContext)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary(new
            {
                controller = "Account",
                action = "Logon",
                returnUrl = filterContext.HttpContext.Request.RawUrl
            });
            filterContext.Result = new RedirectToRouteResult(dictionary);
        }
    }
}
