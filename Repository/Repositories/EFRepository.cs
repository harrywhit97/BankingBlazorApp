using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        readonly DbSet<TEntity> Repository;
        readonly DbContext Context;

        public RepositoryType GetRepositoryType() => RepositoryType.SQLDataBase;

        public EFRepository(DbContext context)
        {
            Context = context;
            Context.Database.EnsureCreated();

            if (!context.Database.CanConnect())
                throw new Exception("Can not connect to database");

            Repository = Context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            Repository.Add(item);
            Context.SaveChanges();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public TEntity Get(long id)
        {
            return Repository.Find(id);
        }

        public IList<TEntity> GetAll()
        {
            return Repository.Where(x => x.Id < 50).ToList();
        }

        public void Remove(TEntity item)
        {
            Repository.Remove(item);
            Context.SaveChanges();
        }

        public void Remove(long id)
        {
            var entity = Get(id);

            if(entity != null)
                Repository.Remove(entity);

            Context.SaveChanges();
        }

        public void AddAll(IList<TEntity> items)
        {
            throw new NotImplementedException();
        }
    }
}
