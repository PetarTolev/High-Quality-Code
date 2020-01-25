namespace ViceCity.Models.Bows.Factory
{
    using Contracts;
    using Zombow.Models.Bows.Contracts;

    public class BowFactory : IBowFactory
    {
        public IBow CreateBow(string type, string name) //todo: use reflection
        {
            if (type == "Takedown")
            {
                return new TakedownBow(name);
            }

            if (type == "Recurve")
            {
                return new RecurveBow(name);
            }

            return null; //todo: add exception
        }
    }
}
