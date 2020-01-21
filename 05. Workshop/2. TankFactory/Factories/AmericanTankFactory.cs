namespace TankManufacturer.Factories
{
    using Units;

    public class AmericanTankFactory : ITankFactory
    {
        public ITank CreateTank()
        {
            return new Tank("Tiger", 4.5, 120);
        }
    }
}
