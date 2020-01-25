using Zombow.Models.Bows.Contracts;
using Zombow.Repositories.Contracts;

namespace Zombow.Models.Players.Contracts
{
    public interface IPlayer
    {
        string Name { get; }

        bool IsAlive { get; }

        IRepository<IBow> BowRepository { get; }

        int LifePoints { get; }

        void TakeLifePoints(int points);
    }
}