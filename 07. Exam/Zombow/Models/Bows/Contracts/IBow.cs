namespace Zombow.Models.Bows.Contracts
{
    public interface IBow
    {
        string Name { get; }

        int QuiverCapacity { get; }

        int TotalArrows { get; }

        bool CanShoot { get; }

        int Shoot();
    }
}