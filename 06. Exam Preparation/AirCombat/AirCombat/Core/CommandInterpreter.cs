namespace AirCombat.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager aircraftManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.aircraftManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0].ToLower();
            inputParameters.RemoveAt(0);

            var method = this.aircraftManager
                .GetType()
                .GetMethods()
                .First(m => m.Name.ToLower().Contains(command));

            if (method == null)
            {
                throw new ArgumentNullException("Command does not exist!");
            }

            if (method.GetParameters().Length > 0)
            {
                return method.Invoke(aircraftManager, new object[] {inputParameters}).ToString();
            }

            return method.Invoke(aircraftManager, new object[] {}).ToString();
        }
    }
}