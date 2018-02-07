using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command_Game.Attack
{
    public class CounterAttack : Command
    {
        public CounterAttack(ICharacter character) : base(character) { }
        public override void Execute()
        {
            this._character.Defense();
            this._character.Attack();
        }
    }
}
