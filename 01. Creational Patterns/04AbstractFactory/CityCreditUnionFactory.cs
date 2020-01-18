namespace AbstractFactory
{
    using Accounts;
    using Accounts.Contracts;

    public class CityCreditUnionFactory : ICreditUnionFactory
    {
        public override ILoanAccount CreateLoanAccount()
        {
            CityLoanAccount obj = new CityLoanAccount();
            return obj;
        }

        public override ISavingsAccount CreateSavingsAccount()
        {
            CitySavingsAccount obj = new CitySavingsAccount();
            return obj;
        }
    }
}