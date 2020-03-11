using Domain.Abstract;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        readonly IList<TEntity> Repository;
        public long? MaxSize { get; set; }

        public InMemoryRepository(long? maxSize = 50)
        {
            Repository = new List<TEntity>();

            //TODO do this better - injegt from config? Or UI
            MaxSize = maxSize;
        }

        public void Add(TEntity item)
        {
            if(MaxSize != null && Repository.Count < MaxSize)
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
