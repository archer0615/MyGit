using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Strategy
{
    public interface ICharacter
    {
        void SetWeapon();
        void SetClothing();
        void WatchStatus();

    }
}
