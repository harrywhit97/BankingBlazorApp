using Domain.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System;
using Microsoft.AspNet.OData;

namespace BankingAPI.Abstract
{
    public abstract class GenericController<TEntity, TValidator> : ControllerBase where TEntity : Entity where TValidator : AbstractValidator<TEntity>
    {
        readonly public DbSet<TEntity> Repository;
        readonly public DbContext Context;
        readonly TValidator Validator;

        public GenericController(DbContext context, TValidator validator)
        {
            context.Database.EnsureCreated();
            Context = context;
            Repository = context.Set<TEntity>();
            Validator = validator;
        }

        [EnableQuery]
        public virtual IEnumerable<TEntity> Get()
        {
            return Repository.AsEnumerable();
        }

        [HttpGet("{id}")]
        public virtual TEntity GetById(long id)
        {
            return Repository.Where(e => e.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public virtual void Add(TEntity entity)
        {
            if (IsValid(entity))
            {
                Repository.Add(entity);
                Context.SaveChanges();
            }
        }

        //[HttpPost]
        public virtual void AddAll(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (IsValid(entity))
                    Repository.Add(entity);
            }
            Context.SaveChanges();
        }

        //[HttpDelete]
        //public virtual void Remove(TEntity entity)
        //{
        //    Repository.Remove(entity);
        //    Context.SaveChanges();
        //}

        [HttpDelete("{id}")]
        public virtual void Remove(long id)
        {
            Repository.Remove(GetById(id));
            Context.SaveChanges();
        }

        [HttpDelete]
        public virtual void Clear()
        {
            Repository.RemoveRange(Get());
            Context.SaveChanges();
        }

        bool IsValid(TEntity entity)
        {
            var results = Validator.Validate(entity);

            if (results.IsValid)
                return true;

            foreach (var error in results.Errors)
            {
                throw new Exception(error.ErrorMessage);
            }
            return false;
        }
    }
}
