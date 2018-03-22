using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Models
{
    public class AverageYield
    {
        public AverageYield()
        {
            Rate = new List<double>();
            Price = new List<double>();
        }
        public string Year { get; set; }
        public List<double> Rate { get; set; }
        public List<double> Price { get; set; }
        public string AverageRate { get { return this.GetAverageRate(); } }
        public string AveragePrice { get { return this.GetAveragePrice(); } }
        public string GetAverageRate()
        {
            if (Rate.Count > 0)
                return Math.Round(Rate.Sum() / Rate.Count, 2).ToString();
            else
                return "0";

        }
        public string GetAveragePrice()
        {
            if (Price.Count > 0)
                return Math.Round(Price.Sum() / Price.Count, 2).ToString();
            else
                return "0.00";
        }
    }
}
