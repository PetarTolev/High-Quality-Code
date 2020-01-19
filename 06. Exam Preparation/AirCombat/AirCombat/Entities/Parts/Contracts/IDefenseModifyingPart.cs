namespace AirCombat.Entities.Parts.Contracts
{
    public interface IDefenseModifyingPart : IPart
    {
        int DefenseModifier { get; }
    }
}