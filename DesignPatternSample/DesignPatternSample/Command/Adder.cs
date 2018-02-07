using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command
{
    public class Adder
    {
        private int num = 0;
        public int Add(int value)
        {
            num += value;
            return this.num;
        }
    }
}
