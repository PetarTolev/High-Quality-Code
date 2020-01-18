namespace FactoryMethod.SavingAccounts
{
    using Contracts;

    public class NationalSavingsAcct : ISavingsAccount
    {
        public NationalSavingsAcct()
        {
            this.Balance = 2000;
        }
    }
}