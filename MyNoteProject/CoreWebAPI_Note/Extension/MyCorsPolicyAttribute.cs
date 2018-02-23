using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI_Note.Extension
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class MyCorsPolicyAttribute : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy corsPolicy;

        public MyCorsPolicyAttribute()
        {
            corsPolicy = new CorsPolicy();
            corsPolicy.Origins.Add("http://myclient.azurewebsites.net");
            corsPolicy.Origins.Add("http://myclient.azurewebsites.net");
        }

        Task<CorsPolicy> ICorsPolicyProvider.GetPolicyAsync(HttpContext context, string policyName)
        {
            throw new NotImplementedException();
        }
    }
}
