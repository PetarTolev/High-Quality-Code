namespace TankManufacturer
{
    using Factories;
    using System;

    public class Program
    {
        static void Main()
        {
            var factories = TankFactoryProvider.InitFactory();

            var americanTank = factories.CreateTank(TankType.American);
            Console.WriteLine(americanTank);

            var germanTank = factories.CreateTank(TankType.German);
            Console.WriteLine(germanTank); 

            var russianTank = factories.CreateTank(TankType.Russian);
            Console.WriteLine(russianTank);

        }
    }
}
