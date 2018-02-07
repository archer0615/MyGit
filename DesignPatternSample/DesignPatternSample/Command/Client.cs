using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command
{
    public class Client 
    {
        public void Run()
        {
            CalcForm cf = new CalcForm();
            AbstractCommand command = new ConcreteCommand();
            cf.setCommand(command);

            cf.compute(5);
            cf.compute(10);
            cf.compute(10);
            cf.Undo(20);
        }
    }
}
