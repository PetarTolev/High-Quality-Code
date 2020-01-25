namespace Zombow
{
    using Core;
    using Core.CommandPattern;
    using Core.CommandPattern.Contracts;
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IController controller = new Controller();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(controller);

            IEngine engine = new Engine(reader, writer, commandInterpreter);
            engine.Run();
        }
    }
}