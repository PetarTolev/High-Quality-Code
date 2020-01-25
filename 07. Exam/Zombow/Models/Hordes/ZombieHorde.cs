namespace Zombow.Models.Hordes
{
    using Contracts;
    using System.Collections.Generic;
    using Zombow.Models.Players.Contracts;

    public class ZombieHorde : IZombieHorde
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> zombies) 
        {
            foreach (var zombie in zombies)
            {
                if ( mainPlayer.BowRepository.Models.Count < 1) //todo: take out methods
                {
                    break;
                }

                if (!zombie.IsAlive)
                {
                    continue;
                }

                foreach (var bow in  mainPlayer.BowRepository.Models)
                {
                    if (!bow.CanShoot)
                    {
                        continue;
                    }

                    while (zombie.IsAlive && bow.CanShoot)
                    {
                        zombie.TakeLifePoints(bow.Shoot());
                    }

                    if (!zombie.IsAlive)
                    {
                        break;
                    }
                }
            }

            foreach (var civilPlayer in zombies)
            {
                if (civilPlayer.BowRepository.Models.Count < 1)
                {
                    break;
                }

                if (!civilPlayer.IsAlive)
                {
                    continue;
                }

                foreach (var bow in civilPlayer.BowRepository.Models)
                {
                    if (!bow.CanShoot)
                    {
                        continue;
                    }

                    while (mainPlayer.IsAlive && bow.CanShoot)
                    {
                        mainPlayer.TakeLifePoints(bow.Shoot());
                    }

                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }

                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}