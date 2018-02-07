using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    internal class Case1
    {
        internal class People
        {
            private Noodles noodles;
            internal People()
            {
                noodles = new Noodles();
            }
            internal void Eat()
            {
                noodles.EatNoodles();
            }
        }

        internal class Noodles
        {
            public void EatNoodles()
            {
                Console.WriteLine("吃麵拉");
            }
        }
    }  
}
