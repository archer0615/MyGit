using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Models
{
    public class YearModel<T>
    {
        public YearModel()
        {
            Years = new List<T>();
        }
        public List<T> Years { get; set; }
    }
}
