using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MyWebAPI.CustomFilter
{
    public class JwtAuthActionFilter : ActionFilterAttribute
    {
        IJsonSerializer serializer = new JsonNetSerializer();
        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        private const string secret = "@mktsupportdbcon!";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null 
                || actionContext.Request.Headers.Authorization.Scheme != "Bearer")
            {
                setErrorResponse(actionContext, "驗證錯誤");
            }
            else
            {
                try
                {
                    DeCodeJwt(actionContext.Request.Headers.Authorization.Parameter);
                    //actionContext.Request.Headers.Authorization.Parameter
                }
                catch (Exception ex)
                {
                    setErrorResponse(actionContext, ex.Message);
                }
            }

            base.OnActionExecuting(actionContext);
        }

        private string EnCodeJwt(string returnVal)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(returnVal, secret);
            return token;
        }
        private string DeCodeJwt(string token)
        {
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
            var json = decoder.Decode(token, secret, verify: true);
            return json;
        }

        private static void setErrorResponse(HttpActionContext actionContext, string message)
        {
            var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
            actionContext.Response = response;
        }
    }
}