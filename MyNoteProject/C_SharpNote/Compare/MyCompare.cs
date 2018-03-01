using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.Compare
{
    public class MyCompare
    {
        List<Emp> empList = new List<Emp>();

        public MyCompare()
        {
            empList.Add(new Emp() { ID = 1, Name = "E1" });
            empList.Add(new Emp() { ID = 2, Name = "E2" });
            empList.Add(new Emp() { ID = 3, Name = "E3" });
            empList.Add(new Emp() { ID = 4, Name = "E4" });
            empList.Add(new Emp() { ID = 5, Name = "E5" });
            empList.Add(new Emp() { ID = 6, Name = "E6" });
        }
        public void RunProcess()
        {
            empList.Sort(new EmpComparer().Compare);
            foreach (var emp in empList)
            {
                Console.WriteLine(emp.ToString());
            }
        }
    }
    public class Emp
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{ID} {Name}";
        }
    }
    public class EmpComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Emp first = (Emp)x;
            Emp second = (Emp)y;
            if (first.ID > second.ID) return -1;
            else if (first.ID < second.ID) return 1;
            else return 0;
        }
    }
}
