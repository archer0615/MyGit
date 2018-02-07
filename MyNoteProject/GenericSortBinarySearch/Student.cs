using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSortBinarySearch
{
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
