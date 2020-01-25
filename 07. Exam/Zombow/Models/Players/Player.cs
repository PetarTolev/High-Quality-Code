namespace Zombow.Models.Players
{
    using System;
    using Zombow.Models.Bows.Contracts;
    using Contracts;
    using Repositories;
    using Zombow.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.BowRepository = new BowRepository();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }
                this.name = value;
            }
        }

        public bool IsAlive => this.lifePoints != 0;

        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                this.lifePoints = value;
            }
        }

        public IRepository<IBow> BowRepository { get; }

        public void TakeLifePoints(int points)
        {
            if (this.lifePoints - points > 0)
            {
                this.lifePoints -= points;
            }
            else
            {
                this.lifePoints = 0;
            }
        }
    }
}