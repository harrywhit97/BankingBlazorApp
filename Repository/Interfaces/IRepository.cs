using Domain.Abstract;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity :Entity
    {
        void Add(TEntity item);
        void Remove(TEntity item);
        void Clear();
        IList<TEntity> GetAll();
        TEntity Get(long id);
    }
}
