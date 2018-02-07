using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.ChainOfResponsibility
{
    public class Manager : ApplyLeaveHandler
    {
        public Manager(string name, int dayNum) : base(name, dayNum)
        {
        }

    }
}
