using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CrawlerWEB.Common
{
    public class MyAuthorize : AuthorizeAttribute
    {
        private AngleSharpEntities db;
        public MyAuthorize()
        {
            db = new AngleSharpEntities();
            var authorizedRoles = db.T_Role.Select(x => x.Role_Name).ToArray();
            Roles = string.Join(",", authorizedRoles);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = false;

            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            bool? auth = (bool?)HttpContext.Current.Session["Auth"];

            if (auth != null && auth.Value)
            {
                result = true;
            }

            if (!result) { throw new Exception("Not Authorized"); }

            return result;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string action = filterContext.ActionDescriptor.ActionName;
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var auth = (bool?)HttpContext.Current.Session["Auth"] ?? false;
            if (!auth)
            {
                filterContext.Result = new RedirectToRouteResult(
                                                        new RouteValueDictionary(
                                                            new { Controller = "Home", Action = "Login" }));
            }

            base.OnAuthorization(filterContext);
        }
    }
}