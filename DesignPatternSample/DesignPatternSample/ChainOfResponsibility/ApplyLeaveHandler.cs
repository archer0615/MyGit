using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.ChainOfResponsibility
{
    public abstract class ApplyLeaveHandler 
    {
        protected string Name;
        protected int DayNum;
        protected ApplyLeaveHandler HighLevelManager;
        public ApplyLeaveHandler(string name, int dayNum)
        {
            this.Name = name;
            this.DayNum = dayNum;
        }

        public void SetNextManager(ApplyLeaveHandler nextManager)
        {
            this.HighLevelManager = nextManager;
        }
        public virtual void RequestApplyLeave(LeavePaper leavePaper)
        {
            if (leavePaper.DayNum <= DayNum)
            {
                Console.WriteLine($"{leavePaper.Name} 請假{leavePaper.DayNum}天 { this.Name} 審核通過 ");
            }
            else
            {
                if (HighLevelManager != null)
                {
                    HighLevelManager.RequestApplyLeave(leavePaper);
                }
                else
                {
                    Console.WriteLine($"{leavePaper.Name} 請假{leavePaper.DayNum}天  沒人可審");
                }
            }
        }
    }
}
