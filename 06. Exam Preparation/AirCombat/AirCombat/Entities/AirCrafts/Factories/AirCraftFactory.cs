namespace AirCombat.Entities.AirCrafts.Factories
{
    using AirCrafts.Contracts;
    using Contracts;
    using Miscellaneous;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AirCraftFactory : IAirCraftFactory
    {
        public IAirCraft CreateAirCraft
            (string aircraftType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Type type = Assembly.GetCallingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name == aircraftType);

            if (type == null)
            {
                throw new ArgumentNullException("This AirCraft type does not exist!");
            }

            IAirCraft aircraft = (IAirCraft)Activator.CreateInstance(type, model, weight, price, attack, defense, hitPoints, new AircraftAssembler());

            return aircraft;
        }
    }
}