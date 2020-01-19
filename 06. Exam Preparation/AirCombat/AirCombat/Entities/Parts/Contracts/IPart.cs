namespace AirCombat.Entities.Parts.Contracts
{
    using CommonContracts;

    public interface IPart : IModelable
    {
        double Weight { get; }

        decimal Price { get; }
    }
}