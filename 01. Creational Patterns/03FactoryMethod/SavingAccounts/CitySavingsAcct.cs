namespace FactoryMethod.SavingAccounts
{
    using Contracts;

    public class CitySavingsAcct : ISavingsAccount
    {
        public CitySavingsAcct()
        {
           this.Balance = 5000;
        }
    }
}