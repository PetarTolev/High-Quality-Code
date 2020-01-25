using System.Collections.Generic;
using System.Linq;
using Zombow.Models.Bows.Contracts;
using Zombow.Repositories.Contracts;

namespace Zombow.Repositories
{
    public class BowRepository : IRepository<IBow>
    {
        private readonly List<IBow> models;

        public BowRepository()
        {
            this.models = new List<IBow>();
        }

        public IReadOnlyCollection<IBow> Models =>
            this.models.AsReadOnly();

        public void Add(IBow model)
        {
            if (this.models.Any(x => x.Name == model.Name))
            {
                return;
            }

            this.models.Add(model);
        }

        public IBow Find(string name)
        {
            IBow gun = this.models.FirstOrDefault(x => x.Name == name);
            return gun;
        }

        public bool Remove(IBow model)
        {
            return this.models.Remove(model);
        }
    }
}