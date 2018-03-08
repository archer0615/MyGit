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
    public  abstract class Day5Model<T>
    {
        public virtual List<T> Days { get; set; }
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
        public StockJuristicVeiwModel()
        {
            Days = new List<Juristic>();
        }
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
}