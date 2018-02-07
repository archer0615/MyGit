using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.ChainOfResponsibility
{
    public class LeavePaper
    {
        private string name;
        public LeavePaper(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int dayNum;
        public int DayNum
        {
            get { return dayNum; }
            set { dayNum = value; }
        }
    }
}
