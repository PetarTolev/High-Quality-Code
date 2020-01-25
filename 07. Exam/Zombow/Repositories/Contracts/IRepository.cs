using System.Collections.Generic;
using Zombow.Models.Bows.Contracts;

namespace Zombow.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(IBow model);

        bool Remove(IBow model);

        IBow Find(string name);
    }
}