using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Strategy
{
    public class Berserker : ICharacter
    {
        public void SetClothing()
        {
            Console.WriteLine("穿重甲");
        }

        public void SetWeapon()
        {
            Console.WriteLine("裝斧");
        }

        public void WatchStatus()
        {
            throw new NotImplementedException();
        }
    }
}
