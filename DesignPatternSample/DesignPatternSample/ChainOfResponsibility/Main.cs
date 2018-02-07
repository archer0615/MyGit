using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.ChainOfResponsibility
{
    public class Main
    {
        public void Run()
        {

            Manager m = new Manager("經理", 1);

            Director d = new Director("協理", 3);

            GeneralManager g = new GeneralManager("總經理", 5);

            m.SetNextManager(d);
            d.SetNextManager(g);

            LeavePaper lp = new LeavePaper("AAA");
            lp.DayNum = 1;
            m.RequestApplyLeave(lp);
            lp.DayNum = 2;
            m.RequestApplyLeave(lp);
            lp.DayNum = 4;
            m.RequestApplyLeave(lp);
            lp.DayNum = 5;
            m.RequestApplyLeave(lp);
            lp.DayNum = 6;
            m.RequestApplyLeave(lp);

        }
    }
}
