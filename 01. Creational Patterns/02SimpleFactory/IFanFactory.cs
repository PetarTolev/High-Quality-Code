namespace SimpleFactory
{
    using Fans.Contracts;

    public interface IFanFactory
    {
        IFan CreateFan(FanType type);
    }
}