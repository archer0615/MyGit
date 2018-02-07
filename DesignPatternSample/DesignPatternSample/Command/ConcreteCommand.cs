using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command
{
    public class ConcreteCommand : AbstractCommand
    {
        private Adder adder = new Adder();
        private int value;
        public override int Execute(int value)
        {
            this.value = value;
            return adder.Add(value);
        }

        public override int Undo(int value)
        {
            this.value = value;
            return adder.Add(-value);
        }
    }
}
