namespace AirCombat.Entities.Parts.Contracts
{
    public interface IAttackModifyingPart : IPart
    {
        int AttackModifier { get; }
    }
}