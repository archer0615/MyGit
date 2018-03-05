using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Models.DTOs
{
    public class T_StockModel
    {
        public string Stock_ID { get; set; }
        public string Stock_Name { get; set; }
        public string Stock_Url { get; set; }
        public int Stock_Category_ID { get; set; }
    }
}
