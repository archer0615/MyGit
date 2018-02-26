using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            stock.GetStockById(2002);
        }
    }
}
