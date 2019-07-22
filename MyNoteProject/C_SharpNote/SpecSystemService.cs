//using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using ROG.DataDefine.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote
{
    public class SpecSystemSetting
    {
        public string apiid { get; set; }
        public string apikey { get; set; }
        public string GetSpecURL { get; set; }
    }
    public class SpecSystemService
    {
        private SpecSystemSetting setting = new SpecSystemSetting();
        public SpecSystemService()
        {
            setting = new SpecSystemSetting();
            setting.apiid = "test";
            setting.apikey = "test";
            setting.GetSpecURL = "https://spec.asus.com/getSpec";
        }
        //public SpecSystemService(IOptions<ExternalAPIOptions> _externalAPIOptions)
        //{
        //    setting = JsonConvert.DeserializeObject<ExternalAPIOptions>(JsonConvert.SerializeObject(_externalAPIOptions.Value))?.SpecSystemSetting;
        //}
        public void GetSpec(List<string> part_no)
        {
            part_no = new List<string>{ "90NB00M1-M00490" };
            string postData = this.setDefaultPostData(new GetSpecInput(part_no));
            string strJsonData =  this.toPostAPI_withArray(setting.GetSpecURL, postData);
            var dto = JsonConvert.DeserializeObject<JObject>(strJsonData);
            //if (dto.Status == 0) return dto;
            //else return null;
        }
        private string toPostAPI_withArray(string post_url, string postData)
        {
            var request = WebRequest.Create(post_url) as HttpWebRequest;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = request.GetResponse() as HttpWebResponse;

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
        private string setDefaultPostData(GetSpecInput getSpecInput)
        {
            string postData = string.Empty;

            postData += $"apiid={setting.apiid}";
            postData += $"&apikey={setting.apikey}";
            postData += this.foreachPart_no(getSpecInput.Part_no);
            if (!string.IsNullOrEmpty(getSpecInput.Siteid)) postData += $"&Siteid={getSpecInput.Siteid}";
            if (!string.IsNullOrEmpty(getSpecInput.Template_id)) postData += $"&Template_id={getSpecInput.Template_id}";
            if (!string.IsNullOrEmpty(getSpecInput.Field)) postData += $"&Siteid={getSpecInput.Field}";
            if (getSpecInput.Field_no != null && getSpecInput.Field_no.Count > 0) postData += this.foreachField_no(getSpecInput.Part_no);

            return postData;
        }
        private string foreachPart_no(List<string> Part_no)
        {
            string result = string.Empty;
            foreach (var item in Part_no)
                result += "&Part_no=" + item;

            return result;
        }
        private string foreachField_no(List<string> Field_no)
        {
            string result = string.Empty;
            foreach (var item in Field_no)
                result += "&Field_no=" + item;

            return result;
        }
        public class GetSpecInput
        {
            public List<string> Part_no { get; set; }
            public string Siteid { get; set; }
            public string Template_id { get; set; }
            public string Field { get; set; }
            public List<string> Field_no { get; set; }
            public GetSpecInput(List<string> part_no, string siteid = "", string template_id = "", string field = "", List<string> field_no = null)
            {
                Part_no = part_no;
                Siteid = siteid;
                Template_id = template_id;
                Field = field;
                Field_no = field_no;
            }
        }
    }
}
