namespace InputValidaotrs
{
    using Interfaces;

    public class SimpleValidator : IValidator
    {
        public bool Validate(string input)
        {
            return input != null;
        }
    }
}
