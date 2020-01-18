namespace FactoryMethod
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var factory = new SavingsAcctFactory();
            var cityAcct = factory.GetSavingsAccount("CITY-321");
            var nationalAcct = factory.GetSavingsAccount("NATIONAL-987");

            var globalAcct = factory.GetSavingsAccountWithRecursion("GLOBAL-123");

            Console.WriteLine(globalAcct.Balance);

            Console.WriteLine($"My city balance is ${cityAcct.Balance}" +
                $" and national balance is ${nationalAcct.Balance}");
        }
    }
}