using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command_Game.Attack
{
    public class SpeedAttack : Command
    {
        public SpeedAttack(ICharacter character) : base(character) { }
        public override void Execute()
        {
            this._character.Dash();
            this._character.Attack();
        }
    }
}
