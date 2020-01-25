namespace Zombow.Core.CommandPattern.Contracts
{
    using System.Collections.Generic;

    public interface ICommandInterpreter
    {
        string ProcessInput(IList<string> inputParameters);
    }
}