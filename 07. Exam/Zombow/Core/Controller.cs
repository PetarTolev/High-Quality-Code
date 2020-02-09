namespace Zombow.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Models.Bows.Factory;
    using ViceCity.Models.Bows.Factory.Contracts;
    using Zombow.Core.Contracts;
    using Zombow.Models.Bows.Contracts;
    using Zombow.Models.Hordes;
    using Zombow.Models.Hordes.Contracts;
    using Zombow.Models.Players;
    using Zombow.Models.Players.Contracts;

    public class Controller : IController
    {
        private readonly List<IPlayer> zombies;
        private readonly IZombieHorde horde;
        private readonly Queue<IBow> bows;
        private readonly MainPlayer mainPlayer;

        private readonly IBowFactory bowFactory;

        public Controller()
        {
            this.zombies = new List<IPlayer>();
            this.bows = new Queue<IBow>();

            this.mainPlayer = new MainPlayer();
            this.horde = new ZombieHorde();

            this.bowFactory = new BowFactory();
        }

        public string AddBow(IList<string> args)
        {
            string type = args[0];
            string name = args[1];

            IBow bow = bowFactory.CreateBow(type, name);  

            if (bow != null)
            { 
                this.bows.Enqueue(bow);
                return $"Successfully added {name} of type: {type}";
            }

            return "Invalid bow type!";
        }

        public string AddBowToPlayer(IList<string> args) //todo: refactor
        {
            string name = args[0];

            string mainPlayerName = "Andrew";

            var player = this.zombies.FirstOrDefault(x => x.Name == name);

            if (player == null && name != "Andrew")
            {
                return "Zombie with that name doesn't exist!";
            }

            if (this.bows.Count != 0)
            {
                var currentBow = this.bows.Dequeue();
                if (name == mainPlayerName)
                {
                    this.mainPlayer.BowRepository.Add(currentBow);
                    return $"Successfully added {currentBow.Name} to the Main Player: Andrew";
                    
                }
                player.BowRepository.Add(currentBow);
                return $"Successfully added {currentBow.Name} to the Zombie: {name}";
            }
            
            return "There are no bows in the queue!";
        }

        public string AddZombie(IList<string> args)
        {
            string name = args[0];

            var zombie = new Zombie(name);
            this.zombies.Add(zombie);

            return $"Successfully added zombie: {zombie.Name}!";
        }

        public string Fight()
        {
            this.horde.Action(this.mainPlayer, this.zombies);

            int killedZombies = this.zombies.RemoveAll(x => !x.IsAlive);

            StringBuilder sb = new StringBuilder();

            if (killedZombies == 0 && this.mainPlayer.LifePoints == 100)
            {
                sb.AppendLine("Everything is okay!");
            }
            else
            {
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Andrew live points: {this.mainPlayer.LifePoints}!");
                sb.AppendLine($"Andrew has killed: {killedZombies} players!");
                sb.AppendLine($"Left Zombies: {this.zombies.Count}!");
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}