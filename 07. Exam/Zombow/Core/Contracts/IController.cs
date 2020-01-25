namespace Zombow.Core.Contracts
{
    using System.Collections.Generic;

    public interface IController
    {
        string AddZombie(IList<string> args);

        string AddBow(IList<string> args);

        string AddBowToPlayer(IList<string> args);

        string Fight();
    }
}