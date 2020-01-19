namespace Facade
{
    using System;

    public class Credit
    {
        public bool HasGoodCredit(Student c)
        {
            Console.WriteLine("Verify credit for " + c.Name);
            return true;
        }
    }
}