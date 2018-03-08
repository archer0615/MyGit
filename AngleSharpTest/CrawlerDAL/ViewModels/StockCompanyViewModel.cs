using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerDAL.ViewModels
{
    public class StockCompanyViewModel
    {
        public string Stock_ID { get; set; }
        public string Company_Url { get; set; }
        public string Catetory_Name { get; set; }
        public string CompanyCreateDate { get; set; }
        public string StockCreateDate { get; set; }
        public string Stock_Capital { get; set; }
        public string Revenue { get; set; }
        public string Company_Official_Url { get; set; }
        public string Company_Fatory { get; set; }
    }
}