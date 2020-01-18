namespace AbstractFactory
{
    public class CreditUnionFactoryProvider
    {
        public static ICreditUnionFactory GetCreditUnionFactory(string accountNo)
        {
            if (accountNo.Contains("CITY")) { return new CityCreditUnionFactory(); }
            if (accountNo.Contains("NATIONAL")) { return new NationalCreditUnionFactory(); }
            return null;
        }
    }
}