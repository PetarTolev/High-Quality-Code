namespace FactoryMethod
{
    using System;
    using System.Linq;
    using System.Reflection;

    using SavingAccounts;
    using SavingAccounts.Contracts;

    public class SavingsAcctFactory : ICreditUnionFactory
    {
        public ISavingsAccount GetSavingsAccount(string acctNo)
        {
            if (acctNo.Contains("CITY"))
            {
                return new CitySavingsAcct();
            }

            if (acctNo.Contains("NATIONAL"))
            {
                return new NationalSavingsAcct();
            }

            throw new ArgumentException("Invalid Account Number");
        }

        public ISavingsAccount GetSavingsAccountWithRecursion(string acctNo)
        {
            var acctType = acctNo.Split('-')[0];

            var savingAccount = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.IsClass && t.Name.ToLower().StartsWith(acctType.ToLower()));

            if (savingAccount != null)
            {
                return (ISavingsAccount)Activator.CreateInstance(savingAccount);
            }

            throw new ArgumentException("This savingAccount type does not exist");
        }
    }
}