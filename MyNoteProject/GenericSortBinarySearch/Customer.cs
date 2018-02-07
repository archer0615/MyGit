using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSortBinarySearch
{
    public class Customer : IComparable<Customer>
    {
        private string CustomerName { get; set; }
        private int Revenue { get; set; }
        private int empCount { get; set; }
        public Customer(string _CustomerName, int _Revenue, int _empCount)
        {
            this.CustomerName = _CustomerName;
            this.Revenue = _Revenue;
            this.empCount = _empCount;
        }
        public override string ToString()
        {
            return this.CustomerName + " 的單位營收為: " + this.Revenue / this.empCount + "元";
        }
        public int CompareTo(Customer other)
        {
            if (this.Revenue / this.empCount == other.Revenue / other.empCount) return 0;
            if (this.Revenue / this.empCount > other.Revenue / other.empCount) return 1;
            return -1;
        }
    }
}
