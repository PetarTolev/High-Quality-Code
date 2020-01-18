namespace SimpleFactory.Fans.Contracts
{
    public interface IFan
    {
        void SwitchOn();
        void SwitchOff();
        string GetState();
    }
}