namespace AirCombat.Entities.AirCrafts
{
    using AirCombat.Entities.Miscellaneous.Contracts;

    public class Bastilon : AirCraft
    {
        public Bastilon(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler)
            : base(model, weight, price, attack, defense, hitPoints, assembler)
        {
        }
    }
}
