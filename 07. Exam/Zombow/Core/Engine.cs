namespace Zombow.Core
{
    using CommandPattern;
    using Contracts;
    using System;
    using System.Linq;
    using Zombow.Core.CommandPattern.Contracts;
    using Zombow.IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICommandInterpreter commandInterpreter;

        public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;

            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                var inputArgs = this.reader.ReadLine().Split(' ').ToList();
                var commandName = inputArgs[0];

                if (commandName == "Exit")
                {
                    break;
                }

                try
                {
                    var command = new Command(this.commandInterpreter, inputArgs);
                    var result = command.Execute();

                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}