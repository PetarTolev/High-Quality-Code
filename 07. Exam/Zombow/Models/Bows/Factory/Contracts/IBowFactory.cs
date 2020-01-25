namespace ViceCity.Models.Bows.Factory.Contracts
{
    using Zombow.Models.Bows.Contracts;

    public interface IBowFactory
    {
        IBow CreateBow(string type, string name);
    }
}