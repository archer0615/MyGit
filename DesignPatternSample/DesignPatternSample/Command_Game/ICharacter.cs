using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command_Game
{
    public interface ICharacter
    {
        void WearClothing();
        void UnloadClothing();
        void HoldWeapon();
        void UnloadWeapon();
        void Attack();
        void Defense();
        void Avoid();
        void Store();
        void Dash();
    }
}
