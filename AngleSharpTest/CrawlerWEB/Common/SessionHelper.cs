using CrawlerDAL.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerWEB.Common
{
    public class SessionHelper
    {
        public static LoginDTO UserData
        {
            get
            {
                return GetSession<LoginDTO>("UserData");
            }
            set
            {
                SetSession("UserData", value);
            }
        }
        private static void SetSession(string sessionName, object value)
        {
            System.Web.HttpContext.Current.Session[sessionName] = JsonConvert.SerializeObject(value);
        }
        private static T GetSession<T>(string sessionName)
        {
            string sessionValue = (string)System.Web.HttpContext.Current.Session[sessionName];
            if (sessionValue == null)
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(sessionValue);
            }
        }
    }
}