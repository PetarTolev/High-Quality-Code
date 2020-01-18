namespace FactoryMethod.SavingAccounts
{
    using Contracts;

    public class GlobalSavingAcct : ISavingsAccount
    {
        public GlobalSavingAcct()
        {
            this.Balance = 10_000;
        }
    }
}