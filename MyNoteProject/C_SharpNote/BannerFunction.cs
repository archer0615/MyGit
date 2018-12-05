using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote
{
    /// <summary>
    /// 動態執行方法function
    /// </summary>
    public class BannerFunction
    {
        public string layout_html(int layout_Id)
        {
            string html = "";
            var tmpType = typeof(BannerLoyout);
            MethodInfo[] metInfos = tmpType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance); //取得所有方法
            foreach (MethodInfo info in metInfos)
            {
                if (info.Name == "GetLayout_" + layout_Id.ToString())
                {
                   var oj = info?.Invoke(tmpType, null);
                }
            }
            return html;
        }

    }
}
