namespace Adapter
{
    using System.Collections.Generic;

    public interface ITarget
    {
        List<string> GetEmployees();
    }
}