using System.Collections.Generic;
using Zombow.Models.Players.Contracts;

namespace Zombow.Models.Hordes.Contracts
{
    public interface IZombieHorde
    {
        void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers);
    }
}