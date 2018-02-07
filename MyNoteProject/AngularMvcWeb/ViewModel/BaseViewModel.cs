using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMvcWeb.ViewModel
{
    public class BaseViewModel
    {
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime AlterDate { get; set; }
        public string AlterUserId { get; set; }
    }
}