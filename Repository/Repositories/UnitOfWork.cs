using Domain.Abstract;
using System;

namespace Repository.Repositories
{
    public class UnitOfWork
    {
        EFDbContext Context = new EFDbContext();

        public Type TheType { get; set; }

        public EFRepository<TEntity> GetRepoInstance<TEntity>() where TEntity : Entity
        {
            return new EFRepository<TEntity>(Context);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
