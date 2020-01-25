namespace Zombow.Core.CommandPattern
{
    using Contracts;
    using System.Collections.Generic;

    public class Command : ICommand
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IList<string> args;

        public Command(ICommandInterpreter commandInterpreter, IList<string> args)
        {
            this.commandInterpreter = commandInterpreter;
            this.args = args;
        }

        public string Execute()
        {
            return this.commandInterpreter.ProcessInput(args);
        }
    }
}