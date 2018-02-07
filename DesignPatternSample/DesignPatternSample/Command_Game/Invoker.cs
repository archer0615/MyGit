using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample.Command_Game
{
    public class Invoker
    {
        private IList<Command> _commands = null;
        public Invoker()
        {
            this._commands = new List<Command>();
        }
        public void AddCommand(Command command)
        {
            this._commands.Add(command);
        }
        public void CancelCommand(Command command)
        {
            this._commands.Remove(command);
        }
        public void Invoke()
        {
            foreach (Command command in this._commands)
                command.Execute();
        }
    }
}
