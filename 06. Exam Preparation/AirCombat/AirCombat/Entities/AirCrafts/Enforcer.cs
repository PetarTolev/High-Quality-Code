namespace AirCombat.Entities.AirCrafts
{
    using AirCombat.Entities.Miscellaneous.Contracts;

    public class Enforcer : AirCraft
    {
        public Enforcer(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler) 
            : base(model, weight, price, attack, defense, hitPoints, assembler)
        {
        }
    }
}
