namespace AirCombat.Entities.Parts
{
    using Contracts;
    using System;

    public class ArsenalPart : Part, IAttackModifyingPart
    {
        private int attackModifier;

        public ArsenalPart(string model, double weight, decimal price, int modifier) 
            : base(model, weight, price)
        {
            this.AttackModifier = modifier;
        }

        public int AttackModifier
        {
            get => this.attackModifier;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Attack modifier cannot be less than zero!");
                }

                this.attackModifier = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"+{this.AttackModifier} Attack";;
        }
    }
}
