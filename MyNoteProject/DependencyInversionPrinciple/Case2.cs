using System;
    
namespace DependencyInversionPrinciple
{
    internal class Case2
    {
        internal class People
        {
            private Rice rice;
            internal People()
            {
                rice = new Rice();
            }
            internal void Eat()
            {
                rice.EatRice();
            }
        }
        internal class Rice
        {
            internal void EatRice()
            {
                System.Console.WriteLine("吃飯拉");
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