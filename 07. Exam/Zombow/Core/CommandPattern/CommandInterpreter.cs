using System.Reflection;

namespace Zombow.Core.CommandPattern
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Zombow.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IController controller;

        public CommandInterpreter(IController controller)
        {
            this.controller = controller;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0].ToLower() + "command";
            inputParameters.RemoveAt(0);

            //todo: extract methods into classes

            //var a = Assembly
            //    .GetExecutingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(x => x.Name.ToLower() == command);

            var method = this.controller
                .GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name.ToLower().Contains(command));

            if (method == null)
            {
                throw new ArgumentNullException("Command does not exist!");
            }

            if (method.GetParameters().Length > 0)
            {
                return method.Invoke(controller, new object[] {inputParameters}).ToString();
            }

            return method.Invoke(controller, new object[] {}).ToString();
        }
    }
}