﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMvcWeb.Extensions.helper
{
    public class ResponsePayload
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}