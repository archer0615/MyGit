using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSortBinarySearch
{
    public class Employee : IComparable<Employee>
    {
        private string employeeName { get; set; }
        public int salary { get; set; }
        public int workHour { get; set; }

        public Employee(string _employeeName, int _salary, int _workHour)
        {
            this.employeeName = _employeeName;
            this.salary = _salary;
            this.workHour = _workHour;
        }
        public override string ToString()
        {
            return this.employeeName + " 的薪水為: " + this.workHour * this.salary + "元";
        }

        public int CompareTo(Employee other)
        {
            if (this.salary / this.workHour == other.salary / other.workHour) return 0;
            if (this.salary / this.workHour > other.salary / other.workHour) return 1;
            return -1;
        }
    }
}
