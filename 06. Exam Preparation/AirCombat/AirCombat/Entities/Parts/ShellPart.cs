namespace AirCombat.Entities.Parts
{
    using Contracts;
    using System;

    public class ShellPart : Part, IDefenseModifyingPart
    {
        private int defenseModifier;

        public ShellPart(string model, double weight, decimal price, int modifier)
            : base(model, weight, price)
        {
            this.DefenseModifier = modifier;
        }

        public int DefenseModifier
        {
            get => this.defenseModifier;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Defense modifier cannot be less than zero!");
                }

                this.defenseModifier = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"+{this.DefenseModifier} Defense";;
        }
    }
}
