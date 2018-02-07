using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Strategy
{
    public class Main
    {
        public void Run()
        {
            ICharacter Jason = new Archer();
            ICharacter Johson = new Berserker();
            ICharacter Mary = new Lancer();
            Jason.SetWeapon();
            Johson.SetWeapon();
            Mary.SetWeapon();

        }  
    }
}
