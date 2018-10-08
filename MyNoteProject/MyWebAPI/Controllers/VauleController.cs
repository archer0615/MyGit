using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using MyWebAPI.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    public class VauleController : ApiController
    {
        [JwtAuthActionFilter]
        public string Get(string id)
        {
            
            //取得token
            if (id == "1")
            {

            }
            else
            {

            }
            return "123";
        }      
    }
}
