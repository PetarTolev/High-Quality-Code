namespace AirCombat.Core
{
    using Contracts;
    using IO.Contracts;
    using System.Linq;
    using Utils;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                var line = this.reader.ReadLine();
                var commandParts = line.Split(' ').ToList();
                var commandName = commandParts[0];

                var command = new GameCommand.GameCommand(this.commandInterpreter, commandParts);
                var result = command.Execute();

                if (commandName == GlobalConstants.TerminateCommand)
                {
                    isRunning = false;
                }

                this.writer.WriteLine(result);
            }
        }
    }
}