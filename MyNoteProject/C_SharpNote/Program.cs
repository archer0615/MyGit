using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_SharpNote.Compare;
using C_SharpNote.EnumHelper;

namespace C_SharpNote
{
    public class Program
    {
        static void Main(string[] args)
        {
            var t = new Task<int>(() =>
             {
                 var x = 0;
                 for (int i = 0; i < 100; i++)
                 {
                     x++;
                 }
                 return x;
             });
            var t2 = new Task<int>(() =>
            {
                var y = 0;
                for (int i = 0; i < 10; i++)
                {
                    y++;
                }
                return y;
            });
            //t.Start();
            var t3 =new Task(() =>
            {
                t.Start();
                t2.Start();
                if (t2.Status == TaskStatus.RanToCompletion) Console.WriteLine(t2.Result);
                if (t.Status == TaskStatus.RanToCompletion) Console.WriteLine(t.Result);
            });
            t3.Start();

            Console.ReadLine();
        }
        //public int GetData()
        //{

        //}
    }
}
