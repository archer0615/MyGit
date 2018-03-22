using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Models
{
    public class MonthModel<T>
    {
        public IList<T> Months { get; set; }
        public MonthModel()
        {
            Months = new List<T>();
        }
    }
}
