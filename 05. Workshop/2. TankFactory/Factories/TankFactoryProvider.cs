namespace TankManufacturer.Factories
{
    using System.Collections.Generic;
    using Units;

    public class TankFactoryProvider
    {
        private static Dictionary<TankType, ITankFactory> factories;

        public static TankFactoryProvider InitFactory()
        {
            factories = new Dictionary<TankType, ITankFactory>
            {
                {TankType.American, new AmericanTankFactory()},
                {TankType.German, new GermanTankFactory()},
                {TankType.Russian, new RussianTankFactory()}
            };

            return new TankFactoryProvider();
        }

        public ITank CreateTank(TankType type)
        {
            return factories[type].CreateTank();
        }
    }
}
