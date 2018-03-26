using CrawlerDAL.DTOs;
using CrawlerWEB.Common;
using Repository;
using StockAngleSharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CrawlerWEB.Controllers
{
    public class HomeController : Controller
    {
        private AngleSharpEntities db;
        public string Roles { get; set; }
        public HomeController()
        {
            db = new AngleSharpEntities();
            var authorizedRoles = db.T_Role.Select(x => x.Role_Name).ToArray();
            Roles = string.Join(",", authorizedRoles);
        }
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
                return RedirectToAction("StockList", "Category");
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
            Session["Auth"] = result;
            UserService US = new UserService();
            try
            {
                if (!string.IsNullOrEmpty(loginData.Account) && !string.IsNullOrEmpty(loginData.Password))
                {
                    var userId = US.LoginValidService(loginData);

                    if (userId > 0)
                    {
                        Session["Auth"] = true;
                        Session["Account"] = loginData.Account;
                        Session["UserId"] = userId;
                        return RedirectToAction("StockList", "Category");
                    }
                    else
                    {
                        ModelState.AddModelError("", "帳號或密碼有誤，請重新輸入。");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(loginData.Account) || string.IsNullOrEmpty(loginData.Password))
                    {
                        ModelState.AddModelError("", "登入資訊不可為空白，請重新輸入。");
                    }
                    else
                    {
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

        public ActionResult Logout()
        {
            Session["Auth"] = false;
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterDTO registerData)
        {
            UserService US = new UserService();
            var Success = US.RegisterAccountService(registerData);
            if (Success)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public void FormAuthentication(LoginDTO loginData)
        {
            var now = DateTime.Now;

            var ticket = new FormsAuthenticationTicket(
                version: 1,
                name: loginData.Account,
                issueDate: now,
                expiration: now.AddMinutes(30),
                isPersistent: false,
                userData: Roles,
                cookiePath: FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);
        }
    }
}