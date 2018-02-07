using AngularProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularProject
{
    public abstract class BaseController : Controller
    {
        public delegate void ResponseDelegate();

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