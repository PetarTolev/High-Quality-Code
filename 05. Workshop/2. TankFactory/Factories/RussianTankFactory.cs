namespace TankManufacturer.Factories
{
    using Units;

    public class RussianTankFactory : ITankFactory
    {
        public ITank CreateTank()
        {
            return new Tank("T 34", 3.3, 75);
        }
    }
}
