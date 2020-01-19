namespace AirCombat.Entities.Parts.Contracts
{
    public interface IHitPointsModifyingPart : IPart
    {
        int HitPointsModifier { get; }
    }
}