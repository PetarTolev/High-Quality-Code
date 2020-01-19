namespace AirCombat.Entities.Parts.Factories
{
    using Contracts;
    using Parts.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PartFactory : IPartFactory
    {
        private const string PartNameSuffix = "Part";

        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Type type = Assembly.GetCallingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name == partType + PartNameSuffix);

            if (type == null)
            {
                throw new ArgumentNullException("This Part type does not exist!");
            }

            IPart part = (IPart)Activator.CreateInstance(type, model, weight, price, additionalParameter);

            return part;
        }
    }
}