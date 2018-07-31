using JWT;
using JWT.Algorithms;
using JWT.Serializers;
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
        public string Get(string id)
        {
            var payload = new Dictionary<string, string> //模擬到時候伺服器想接收的資料
	                {
                        { "account", "kinanson" },
                        { "role", "admin" }
                    };
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();

            string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

            string jwt = EnCodeJwt(payload, secret, serializer, urlEncoder);
            var getUserInfo = DeCodeJwt(jwt, secret, serializer, urlEncoder);
            //取得token
            if (id == "1")
            {

            }
            else
            {

            }
            return "123";
        }
        private string EnCodeJwt(Dictionary<string, string> userInfo,string secret, IJsonSerializer serializer, IBase64UrlEncoder urlEncoder)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(userInfo, secret);
            return token;
        }
        private string DeCodeJwt(string token, string secret, IJsonSerializer serializer, IBase64UrlEncoder urlEncoder)
        {
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
            var json = decoder.Decode(token, secret, verify: true);
            return json;
        }
    }
}
