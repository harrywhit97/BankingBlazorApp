using Repository.Abstract;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity :Entity
    {
        void Add(TEntity item);
        void AddAll(IList<TEntity> items);
        void Remove(TEntity item);
        void Remove(long id);
        void Clear();
        IList<TEntity> GetAll();
        TEntity Get(long id);
        RepositoryType GetRepositoryType();
    }
}
