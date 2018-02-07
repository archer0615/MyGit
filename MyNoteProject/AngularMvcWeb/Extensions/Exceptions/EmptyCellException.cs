using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMvcWeb.Extensions.Exceptions
{
    public class EmptyCellException : Exception
    {
        public EmptyCellException(string msg) : base(msg)
        {
        }
    }
}