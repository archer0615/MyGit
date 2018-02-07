using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command_Game.Attack
{
    public class CommonAttack : Command
    {
        public CommonAttack(ICharacter character) : base(character) { }
        public override void Execute()
        {
            this._character.Attack();
        }
    }
}
