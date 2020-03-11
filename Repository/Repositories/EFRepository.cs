using Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        readonly DbContext Context;
        readonly DbSet<TEntity> Repository;

        public EFRepository(DbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Database.CanConnect())
                throw new Exception("Can not connect to database");

            Context = context;
            Repository = context.Set<TEntity>();
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
        }
    }
}
