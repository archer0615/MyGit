using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AngularMvcWeb.Extensions.helper
{
    public class ConfigHelper
    {
        public static string GetConfigValue(string key)
        {
            string result = string.Empty;
            try
            {
                result = ConfigurationManager.AppSettings[key];
            }
            catch (Exception)
            { }

            return result;
        }
        public static IDictionary<string, string> GetConfigValuesStartsWith(string key)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = (from string s in appSettings.Keys
                          where s.StartsWith(key)
                          select new
                          {
                              Key = s,
                              Value = appSettings[s]
                          })
                          .ToDictionary(x => x.Key, x => x.Value);
            }
            catch
            { }

            return result;
        }
    }
}