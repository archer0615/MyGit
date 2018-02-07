using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.Notes
{
    public class MathRoundBug
    {
        public void MainFunction()
        {
            decimal test = 2.5m;
            Console.WriteLine("Math.Rount()");
            Console.WriteLine($"2.5 :{Math.Round(2.5)}  ???");
            Console.WriteLine("Math.Rount(, MidpointRounding.AwayFromZero)");
            Console.WriteLine($"2.5 :{Math.Round(2.5, MidpointRounding.AwayFromZero)}");
            Console.WriteLine();

            Console.WriteLine("Math.Rount()");
            Console.WriteLine($"122.5 :{Math.Round(122.5)}");
            Console.WriteLine("Math.Rount(, MidpointRounding.AwayFromZero)");
            Console.WriteLine($"122.5 :{Math.Round(122.5, MidpointRounding.AwayFromZero)}");
            Console.WriteLine();

            Console.WriteLine("Math.Rount()");
            Console.WriteLine($"2.135 :{Math.Round(2.135, 2)}");
            Console.WriteLine("Math.Rount(, MidpointRounding.AwayFromZero)");
            Console.WriteLine($"2.135 :{Math.Round(2.135, 2, MidpointRounding.AwayFromZero)}");

            Console.WriteLine();
            Console.WriteLine($"0.135 :{Math.Round(0.135, 2, MidpointRounding.AwayFromZero)}");
            Console.WriteLine();
        }        
    }
}
