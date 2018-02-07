using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.Notes
{
    public class GenericSortBinarySearch
    {
        static void Main(string[] args)
        {

        }
    }
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
    public class SearchTree<T> where T : IComparable<T>
    {
        private T NodeData { get; set; }
        private SearchTree<T> LeftTree { get; set; }
        private SearchTree<T> RightTree { get; set; }

        public SearchTree(T nodeValue)
        {
            this.NodeData = nodeValue;
            this.LeftTree = null;
            this.RightTree = null;
        }
        public void InsertNode(T newItem)
        {
            T currentNodeValue = this.NodeData;

            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                if (this.LeftTree == null)
                    this.LeftTree = new SearchTree<T>(newItem);
                else
                    this.LeftTree.InsertNode(newItem);
            }
            else
            {
                if (this.RightTree == null)
                    this.RightTree = new SearchTree<T>(newItem);
                else
                    this.RightTree.InsertNode(newItem);
            }
        }
        public void ViewTree()
        {
            if (this.LeftTree != null)
            {
                this.LeftTree.ViewTree();
            }
            Console.WriteLine(this.NodeData.ToString());
            if (this.RightTree != null)
            {
                this.RightTree.ViewTree();
            }
        }
    }
    public class Student : IComparable<Student>
    {
        public class Course
        {
            public int ProjectCount { get; set; }
            public int Score { get; set; }
        }
        private string StudentName { get; set; }
        private List<Course> CourseList { get; set; }
        public Student(string _StudentName, List<Course> _courseList)
        {
            this.StudentName = _StudentName;
            this.CourseList = _courseList;
        }

        public int CompareTo(Student other)
        {
            if (this.CourseList.Sum(x => x.Score * x.ProjectCount) == other.CourseList.Sum(x => x.Score * x.ProjectCount)) return 1;
            if (this.CourseList.Sum(x => x.Score * x.ProjectCount) > other.CourseList.Sum(x => x.Score * x.ProjectCount))
                return 0;

            return -1;
        }
    }
}
