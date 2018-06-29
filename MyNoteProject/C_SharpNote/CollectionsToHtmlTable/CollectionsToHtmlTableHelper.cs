using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace C_SharpNote.CollectionsToHtmlTable
{
    public static class CollectionsToHtmlTableHelper
    {
        public static string ToHtmlTable(this HashSet<dynamic> obj) => ToHtmlTableConverter(obj);
        public static string ToHtmlTable(this ICollection obj) => ToHtmlTableConverter(obj);
        public static string ToHtmlTable(this DataTable obj) => ConvertDataTableToHTML(obj);

        private static string ToHtmlTableConverter(object obj)
        {
            var jsonStr = JsonConvert.SerializeObject(obj);
            var data = JsonConvert.DeserializeObject<DataTable>(jsonStr);
            var html = ConvertDataTableToHTML(data);
            return html;
        }

        private static string ConvertDataTableToHTML(DataTable dt)
        {
            var html = new StringBuilder("<table>");

            //表頭
            html.Append("<thead><tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
                html.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            html.Append("</tr></thead>");

            //表身
            html.Append("<tbody>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html.Append("<tr>");
                for (int j = 0; j < dt.Columns.Count; j++)
                    html.Append("<td>" + dt.Rows[i][j].ToString() + "</td>");
                html.Append("</tr>");
            }

            html.Append("</tbody>");
            html.Append("</table>");
            return html.ToString();
        }

        public static void RunProcess()
        {
            var collections = new List<dynamic>();
            for (int i = 0; i < 5; i++)
                collections.Add(
                     new
                     {
                         名稱 = string.Format("IT邦{0}", i),
                         帳號 = i,
                         密碼 = Guid.NewGuid()
                     }
                );
            ;
            var colls1 = collections.ToArray().ToHtmlTable(); //Run Success
            //var colls2 = collections.ToHashSet().ToHtmlTable();//Run Succes
            var colls_list = collections.ToList().ToHtmlTable();//Run Succes
        }
    }
}
