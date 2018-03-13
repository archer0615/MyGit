using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerDAL.ViewModels
{
    public class StockViewModel
    {
        public string StockID { get; set; }
        public string StockName { get; set; }
        public string StockURL { get; set; }
        public int CategoryID { get; set; }
    }
    public class StockNowPriceViewModel
    {
        public string Price { get; set; }
        public string GainDrop { get; set; }
        public string Color { get; set; }
    }
    public class StockCrawlerModel
    {
        public string StockID { get; set; }
        public string StockName { get; set; }
        public string StockTime { get; set; }
        public string StockDeal { get; set; }
        public string StockBuy { get; set; }
        public string StockSell { get; set; }
        public string StockGainDrop { get; set; }
        public string StockShareCount { get; set; }
        public string StockYesterday { get; set; }
        public string StockOpen { get; set; }
        public string StockTop { get; set; }
        public string StockDown { get; set; }
    }
    public abstract class Day5Model<T>
    {
        public virtual List<T> Days { get; set; }
    }
    public abstract class YearModel<T>
    {
        public virtual List<T> Years { get; set; }
    }
    public class Stock5DayGainDropViewModel : Day5Model<GainDrop>
    {

        public Stock5DayGainDropViewModel()
        {
            Days = new List<GainDrop>();
        }
    }
    public class StockJuristicVeiwModel : Day5Model<Juristic>
    {
        public StockJuristicVeiwModel() { Days = new List<Juristic>(); }
    }
    public class StockYieldsViewModel : YearModel<Yield>
    {
        public StockYieldsViewModel() { Years = new List<Yield>(); }
    }
    public class AverageYieldViewModel : YearModel<AverageYield>
    {
        public AverageYieldViewModel() { Years = new List<AverageYield>(); }
    }
    public class Yield
    {
        public string YieldYear { get; set; }
        public string YieldRate { get; set; }
        public string MonthPrice { get; set; }   
    }
    public class GainDrop
    {
        public string GainDropDate { get; set; }
        public string Per { get; set; }
    }
    public class Juristic
    {
        public string JuristicDate { get; set; }
        public string Foreign { get; set; }
        public string Investment { get; set; }
        public string Self { get; set; }
        public string Total { get; set; }
    }
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