namespace Zombow.Models.Bows
{
    using System;
    using Contracts;

    public abstract class Bow : IBow
    {
        private string name;
        private int quiverCapacity;
        private int totalArrows;

        protected Bow(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public int QuiverCapacity
        {
            get => this.quiverCapacity;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Arrows cannot be below zero!");
                }
                this.quiverCapacity = value;
            }
        }

        public int TotalArrows
        {
            get => this.totalArrows;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total arrows cannot be below zero!");
                }
                this.totalArrows = value;
            }
        }

        public virtual bool CanShoot => this.quiverCapacity > 0 || this.totalArrows > 0;

        public abstract int Shoot();

        protected abstract void Reload();
    }
}