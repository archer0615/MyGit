﻿using CrawlerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.ViewModels
{
    public class StockJuristicVeiwModel : Day5Model<Juristic>
    {
        public StockJuristicVeiwModel() { Days = new List<Juristic>(); }
    }
}
