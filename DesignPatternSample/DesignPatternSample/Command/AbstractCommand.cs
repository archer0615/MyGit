using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command
{
    public abstract class AbstractCommand
    {
        public abstract int Execute(int value);
        public abstract int Undo(int value);
    }
}
