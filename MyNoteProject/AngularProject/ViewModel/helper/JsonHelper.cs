using System;
using System.Collections.Generic;
using System.IO;
using Jil;
using System.Linq;
using System.Web;

namespace AngularProject.ViewModel.helper
{
    public class JsonHelper
    {
        /// <summary>
        /// 將物件序列化成JSON字串
        /// </summary>
        /// <param name="data">物件Object</param>
        /// <returns></returns>
        public static string ConvertObjectToJsonString(object data)
        {
            using (var output = new StringWriter())
            {
                JSON.Serialize(data, output);
                return output.ToString();
            }
        }

        /// <summary>
        /// 將JSON字串反序列化成物件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString">JSON字串</param>
        /// <returns></returns>
        public static T ConvertJsonStringToObject<T>(string jsonString)
        {
            return JSON.Deserialize<T>(jsonString);
        }
    }
}