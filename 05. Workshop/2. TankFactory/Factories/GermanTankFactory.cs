namespace TankManufacturer.Factories
{
    using Units;

    public class GermanTankFactory : ITankFactory
    {
        public ITank CreateTank()
        {
            return new Tank("M1 Abrams", 5.4, 120);
        }
    }
}
