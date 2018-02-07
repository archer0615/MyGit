using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.ChainOfResponsibility
{
    public class GeneralManager : ApplyLeaveHandler
    {
        public GeneralManager(string name, int dayNum) : base(name, dayNum)
        {
        }
    }
}
