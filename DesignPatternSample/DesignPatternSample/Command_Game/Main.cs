using DesignPatternSample.Command_Game.Attack;
using DesignPatternSample.Command_Game.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command_Game
{
    public static class Main
    {
        public static void Run()
        {
            ICharacter emiya = new Archer("emiya");
            ICharacter artoria = new Saber("artoria");
            ICharacter cu_chulainn = new Lancer("cu_chulainn");

            Invoker invoker = new Invoker();
            List<Command> commandsPK = new List<Command>()
            {
                new CommonAttack(emiya),
                new SpeedAttack(artoria),
                new CounterAttack(cu_chulainn)
            };
            commandsPK.ForEach(cmd => { invoker.AddCommand(cmd); });

            invoker.Invoke();
        }
    }
}
