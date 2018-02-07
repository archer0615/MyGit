using MVC_Repository.Models.Interface;
using MVC_Repository.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Repository.Controllers
{
    public class HomeController : Controller
    {
        private IGetOrderRepository<GetOrderListResponseModel> repository;
        public HomeController()
        {
            repository = new GetOrderRepository<GetOrderListResponseModel>();
        }
        // GET: Home
        public ActionResult Index()
        {
            repository.Error("test");
            return View();
        }
    }
}