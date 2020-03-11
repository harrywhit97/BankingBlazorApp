using Domain.Abstract;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        readonly IList<TEntity> Repository;

        public InMemoryRepository()
        {
            Repository = new List<TEntity>();
        }

        public void Add(TEntity item)
        {
            Repository.Add(item);
        }

        public void Clear()
        {
            Repository.Clear();
        }

        public TEntity Get(long id)
        {
            return Repository.Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<TEntity> GetAll()
        {
            return Repository;
        }

        public void Remove(TEntity item)
        {
            Repository.Remove(item);
        }
    }
}
