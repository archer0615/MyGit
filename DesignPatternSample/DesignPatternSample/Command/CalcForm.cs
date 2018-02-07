using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command
{
    public class CalcForm
    {
        private AbstractCommand command;
        public void setCommand(AbstractCommand command)
        {
            this.command = command;
        }
        public void compute(int value)
        {
            int i = command.Execute(value);
            Console.WriteLine($"執行 :  {i}");
        }
        public void Undo(int value)
        {
            int i = command.Undo(value);
            Console.WriteLine($"執行回復 : {i}");
        }

    }
}
