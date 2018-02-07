using AngularMvcWeb.Extensions.helper;
using Jil;
using System.Collections.Generic;
using System;
using System.Web.Mvc;

namespace AngularMvcWeb.Controllers
{
    public abstract class BaseController<T> : Controller
    {
        //public ResponsePayload response = new ResponsePayload();
        public delegate void ResponseDelegate();

        public abstract ActionResult Create();
        public abstract JsonResult Create(T data);
        public abstract ActionResult Edit(int id);
        public abstract JsonResult Edit(T data);
        public abstract JsonResult Delete(int id);
        public abstract JsonResult Get(int id);
        public abstract JsonResult GetAll();

        public JsonResult ExecService(ResponseDelegate serviceDelegate, ResponsePayload response)
        {
            try
            {
                serviceDelegate(); //執行服務
                response.Success = true;
            }
            catch (ValidationErrors errors)
            {
                response.Success = false;
                foreach (var error in errors.Errors)
                {
                    response.Message += error.PropertyExceptionMessage + "<br>";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                response.Success = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }
    }
}