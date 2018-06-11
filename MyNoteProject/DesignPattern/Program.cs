using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Flyweight_Pattern;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Component component = ComponentFactory.createComponent("Tree");
            component.setLocation(1, 1);
            component = ComponentFactory.createComponent("Building");
            component.setLocation(1, 2);
            component = ComponentFactory.createComponent("Building");
            component.setLocation(2, 2);
            component = ComponentFactory.createComponent("Road");
            component.setLocation(3, 3);
            component = ComponentFactory.createComponent("Road");
            component.setLocation(3, 4);
            component = ComponentFactory.createComponent("Road");
            component.setLocation(3, 5);
            Console.WriteLine();
        }
    }
}
