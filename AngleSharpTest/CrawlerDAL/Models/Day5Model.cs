using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Models
{
    public abstract class Day5Model<T>
    {
        public virtual List<T> Days { get; set; }
    }
}
