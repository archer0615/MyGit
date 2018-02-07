using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Strategy
{
    public class Lancer : ICharacter
    {
        public void SetClothing()
        {
            Console.WriteLine("穿輕甲");
        }

        public void SetWeapon()
        {
            Console.WriteLine("裝槍");
        }

        public void WatchStatus()
        {
            throw new NotImplementedException();
        }
    }
}
