namespace FactoryMethod
{
    using SavingAccounts.Contracts;

    public interface ICreditUnionFactory
    {
        ISavingsAccount GetSavingsAccount(string acctNo);
    }
}