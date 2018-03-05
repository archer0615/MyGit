using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Models
{
    public class StockCompany
    {
        public string BossCash { get; set; }
        public string BossShare { get; set; }        
    }
    public class StockGain
    {
        public string 營業毛利率 { get; set; }
        public string 營業利益率 { get; set; }
        public string 稅前淨利率 { get; set; }

        public string 資產報酬率 { get; set; }
        public string 股東權益報酬率 { get; set; }
    }
    public class Last4_SeasonGain
    {
        public string One_Season { get; set; }
        public string Two_Season { get; set; }
        public string Three_Season { get; set; }
        public string Four_Season { get; set; }
    }
    public class Last4_YearGain
    {
        public string One_Year{ get; set; }
        public string Two_Year { get; set; }
        public string Three_Year { get; set; }
        public string Four_Year { get; set; }
    }

}
