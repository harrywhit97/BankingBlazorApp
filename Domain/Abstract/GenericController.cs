using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Abstract
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class GenericController<TEntity> : ControllerBase where TEntity : Entity
    {
        readonly public DbSet<TEntity> Repository;
        readonly public DbContext Context;

        public GenericController(DbContext context)
        {
            context.Database.EnsureCreated();

            Context = context;
            Repository = context.Set<TEntity>();
        }

        [HttpGet]
        public IEnumerable<TEntity> GetAll()
        {
            return Repository.AsEnumerable();
        }

        [HttpGet("{id}")]
        public TEntity GetById(long id)
        {
            return Repository.Where(e => e.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public void Add(TEntity entity)
        {
            Repository.Add(entity);
            Context.SaveChanges();
        }

        [HttpDelete]
        public void Remove(TEntity entity)
        {
            Repository.Remove(entity);
            Context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Remove(long id)
        {
            Repository.Remove(GetById(id));
            Context.SaveChanges();
        }

        [HttpDelete]
        public void Clear()
        {
            Repository.RemoveRange(GetAll());
            Context.SaveChanges();
        }
    }
}
