using CrawlerDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Selectors
{
    public class CompanySelector : ISelector
    {
        public string mainSelector { get; set; }
        public CompanySelector(string _mainSelector)
        {
            mainSelector = _mainSelector;
        }
        /// <summary>
        /// 公司創立時間
        /// </summary>
        public string CompanyCreateDate { get; set; }
        /// <summary>
        /// 公司上市時間
        /// </summary>
        public string StockCreateDate { get; set; }
        /// <summary>
        /// 股本
        /// </summary>
        public string Stock_Capital { get; set; }
        /// <summary>
        /// 營收比重
        /// </summary>
        public string Revenue { get; set; }
        /// <summary>
        /// 公司網站
        /// </summary>
        public string Company_Official_Url { get; set; }
        /// <summary>
        /// 工廠
        /// </summary>
        public string Company_Fatory { get; set; }
    }
}
