using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command_Game
{
    public abstract class Command
    {
        protected ICharacter _character = null;
        public Command(ICharacter character)
        {
            this._character = character;
        }
        public abstract void Execute();
    }
}
