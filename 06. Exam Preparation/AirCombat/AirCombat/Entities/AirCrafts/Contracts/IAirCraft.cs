namespace AirCombat.Entities.AirCrafts.Contracts
{
    using CommonContracts;
    using Parts.Contracts;
    using System.Collections.Generic;

    public interface IAirCraft : IModelable
    {
        double Weight { get; }

        decimal Price { get; }

        int Attack { get; }

        int Defense { get; }

        int HitPoints { get; }

        double TotalWeight { get; }

        decimal TotalPrice { get; }

        long TotalAttack { get; }

        long TotalDefense { get; }

        long TotalHitPoints { get; }

        void AddArsenalPart(IPart arsenalPart);

        void AddShellPart(IPart shellPart);

        void AddEndurancePart(IPart endurancePart);

        IEnumerable<IPart> Parts { get; }
    }
}