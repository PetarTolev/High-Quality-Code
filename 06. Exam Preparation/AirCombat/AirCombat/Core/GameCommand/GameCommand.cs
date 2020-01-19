namespace AirCombat.Core.GameCommand
{
    using AirCombat.Core.Contracts;
    using AirCombat.Core.GameCommand.Contracts;
    using System.Collections.Generic;

    public class GameCommand : ICommand
    {
        private readonly IList<string> parameters;

        private readonly ICommandInterpreter commandInterpreter;

        public GameCommand(ICommandInterpreter commandInterpreter, IList<string> inputParameters)
        {
            this.parameters = inputParameters;
            this.commandInterpreter = commandInterpreter;
        }

        public string Execute()
        {
            return this.commandInterpreter.ProcessInput(this.parameters);
        }
    }
}
