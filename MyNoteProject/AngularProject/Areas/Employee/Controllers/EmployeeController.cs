using AngularProject.Models.DB;
using AngularProject.ViewModel;
using AngularProject.ViewModel.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularProject.Areas.Employee.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee/Employee
        public ActionResult Index()
        {
            return View();
        }
    }
}