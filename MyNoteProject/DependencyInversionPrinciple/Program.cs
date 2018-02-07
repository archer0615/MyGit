using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> A = new List<int>() { 1, 2, 3, 5, 9 };
            List<int> B = new List<int>() { 4, 3, 9 };
            var expectedList = A.Except(B);
            foreach (var item in expectedList)
            {
                Console.WriteLine(item);
            }
            
            //Case_1();//單純吃麵
            //Case_2();//原先吃麵 但是需求變更成需要吃飯
            //Case_3();//抽出介面 要吃啥都可以了
        }
        private static void Case_1()
        {
            Case1.People me = new Case1.People();
            me.Eat();
        }
        private static void Case_2()
        {
            Case2.People me = new Case2.People();
            me.Eat();
        }
        private static void Case_3()
        {
            Case3.People me = new Case3.People();
            me.Eat(Case3.EnumFood.Rice);
            Console.WriteLine($"飽食度目前 : {me.Satiation}");
            Console.WriteLine($"{me.ateFood}");
            me.Eat(Case3.EnumFood.Noodles);
            Console.WriteLine($"飽食度目前 : {me.Satiation}");
            Console.WriteLine($"{me.ateFood}");
            me.Eat(Case3.EnumFood.Noodles);
            Console.WriteLine($"飽食度目前 : {me.Satiation}");
            Console.WriteLine($"{me.ateFood}");
            me.Eat(Case3.EnumFood.Rice);
            Console.WriteLine($"飽食度目前 : {me.Satiation}");
            Console.WriteLine($"{me.ateFood}");
        }
    }
}
