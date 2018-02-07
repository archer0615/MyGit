using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternSample.Strategy;

namespace DesignPatternSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChainOfResponsibility.Main test = new ChainOfResponsibility.Main();
            //test.Run();

            //Command.Client testCommand = new Command.Client();
            //testCommand.Run();
            Command_Game.Main.Run();
        }
    }
}
