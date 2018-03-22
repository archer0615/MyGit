using CrawlerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.ViewModels
{
    public class Stock5DayGainDropViewModel : Day5Model<GainDrop>
    {

        public Stock5DayGainDropViewModel()
        {
            Days = new List<GainDrop>();
        }
    }
}
