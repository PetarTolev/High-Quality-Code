namespace AbstractFactory
{
    using Accounts.Contracts;

    public abstract class ICreditUnionFactory
    {
        public abstract ISavingsAccount CreateSavingsAccount();

        public abstract ILoanAccount CreateLoanAccount();
    }
}