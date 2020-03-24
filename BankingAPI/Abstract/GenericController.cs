using Domain.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.AspNet.OData;

namespace BankingAPI.Abstract
{
    public abstract class GenericController<TEntity, TValidator> : ODataController where TEntity : Entity where TValidator : AbstractValidator<TEntity>
    {
        readonly protected DbSet<TEntity> Repository;
        readonly protected DbContext Context;
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

        [EnableQuery]
        public virtual ActionResult<TEntity> Get([FromODataUri] long key)
        {
            var entity = Repository.Find(key);
            if(entity is null)
                return NotFound();
            return entity;
        }

        public virtual IActionResult Post([FromBody] TEntity entity)
        {
            if (entity is null || !IsValid(entity))
                return BadRequest();

            Repository.Add(entity);
            Context.SaveChanges();
            return Created(entity);
        }

        public virtual IActionResult Delete([FromODataUri] long key)
        {
            var entity = Repository.Find(key); ;

            if (entity is null)
                return NotFound();

            Repository.Remove(entity);
            Context.SaveChanges();
            return Ok();
        }

        public IActionResult Patch([FromODataUri] long key, [FromBody] Delta<TEntity> entityDelta)
        {           
            var entity = Repository.Find(key);
            
            if (entity is null)
                return NotFound();

            entityDelta.Patch(entity);
            
            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(key))
                    return NotFound();
                else
                    throw;
            }

            return Updated(entity);
        }

        public IActionResult Put([FromODataUri]long key, [FromBody] TEntity update)
        {
            if (!IsValid(update))
                return BadRequest(ModelState);

            if (key != update.Id)
                return BadRequest();

            Context.Entry(update).State = EntityState.Modified;
            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        bool EntityExists(long key)
        {
            return Repository.Any(x => x.Id == key);
        }

        bool IsValid(TEntity entity)
        {
            var results = Validator.Validate(entity);
            return results.IsValid;
        }
    }
}
