using CrawlerDAL.DTOs;
using StockAngleSharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrawlerWEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.UrlReferrer == null || !Convert.ToBoolean(Session["Auth"]))
            {
                Session.Clear();
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            Session.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDTO loginData)
        {
            var result = false;
            UserService US = new UserService();
            try
            {
                if (!string.IsNullOrEmpty(loginData.Account) && !string.IsNullOrEmpty(loginData.Password))
                {
                    result = US.LoginValidService(loginData);

                    if (result)
                    {
                        return RedirectToAction("StockList", "Category");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(loginData.Account) || string.IsNullOrEmpty(loginData.Password))
                    {
                        Session["Auth"] = false;
                        ModelState.AddModelError("", "登入資訊不可為空白，請重新輸入。");
                    }
                    else
                    {
                        Session["Auth"] = false;
                        ModelState.AddModelError("", "登入資訊有誤，請重新輸入。");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
    }
}