using AirCombat.Entities.AirCrafts.Contracts;

namespace AirCombat.Entities.AirCrafts.Factories.Contracts
{
    public interface IAirCraftFactory
    {
        IAirCraft CreateAirCraft(string aircraftType, string model, double weight, decimal price, int attack, int defense, int hitPoints);
    }
}