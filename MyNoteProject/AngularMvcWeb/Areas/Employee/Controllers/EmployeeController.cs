using AngularMvcWeb.Controllers;
using AngularMvcWeb.Extensions.helper;
using AngularMvcWeb.Models.DB;
using AngularMvcWeb.Services.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularMvcWeb.Areas.Employee.Controllers
{
    public class EmployeeController : BaseController<Employees>
    {
        private EmployeeService empService;

        public EmployeeController()
        {
            empService = new EmployeeService();
        }
        public override ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public override JsonResult Create(Employees data)
        {
            throw new NotImplementedException();
        }

        public override JsonResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override JsonResult Edit(Employees data)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public override JsonResult Get(int id)
        {
            ResponsePayload response = new ResponsePayload();
            ResponseDelegate myDelegate = () =>
            {
                var result = empService.GetEmployee(id);
                response.Data = new { data = result };
            };
            return ExecService(myDelegate, response);
        }

        [HttpPost]
        public override JsonResult GetAll()
        {
            ResponsePayload response = new ResponsePayload();
            ResponseDelegate myDelegate = () =>
            {
                var result = empService.GetAllEmployees();
                response.Data = new { data = result };
            };
            return ExecService(myDelegate, response);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}