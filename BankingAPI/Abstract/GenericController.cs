using Domain.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FluentValidation;
using Microsoft.AspNet.OData;

namespace BankingAPI.Abstract
{
    public abstract class GenericController<TEntity, TValidator> : ReadOnlyController<TEntity> where TEntity : Entity where TValidator : AbstractValidator<TEntity>
    {
        readonly TValidator Validator;

        public GenericController(DbContext context, TValidator validator) : base(context)
        {
            Validator = validator;
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
                    return NotFound();
                else
                    throw;
            }
            return Updated(update);
        }

        bool EntityExists(long key) => Repository.Any(x => x.Id == key);

        bool IsValid(TEntity entity)
        {
            var results = Validator.Validate(entity);
            return results.IsValid;
        }
    }
}
