namespace AirCombat.Entities.Parts
{
    using Contracts;
    using System;

    public class EndurancePart : Part, IHitPointsModifyingPart
    {
        private int hitPointsModifier;

        public EndurancePart(string model, double weight, decimal price, int modifier) 
            : base(model, weight, price)
        {
            this.HitPointsModifier = HitPointsModifier;
        }

        public int HitPointsModifier 
        { 
            get => this.hitPointsModifier;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hit points modifier cannot be less than zero!");
                }

                this.hitPointsModifier = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"+{this.HitPointsModifier} HitPoints";;
        }
    }
}
