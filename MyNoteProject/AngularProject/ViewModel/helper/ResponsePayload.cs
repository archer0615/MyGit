using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularProject.ViewModel
{
    public class ResponsePayload
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}