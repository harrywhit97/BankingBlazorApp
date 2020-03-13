using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Abstract;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Domain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class GenericController<TEntity> : ControllerBase where TEntity : Entity
    {
        readonly IRepository<TEntity> Repository;

        public GenericController(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        // GET: api/pressureReadings
        [HttpGet]
        public IList<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        [HttpGet("{id}")]
        public TEntity Get([FromQuery]long id)
        {
            return Repository.Get(id);
        }

        [HttpPost]
        public void Add(TEntity entity)
        {
            Repository.Add(entity);
        }

        [HttpDelete]
        public void Remove(TEntity entity)
        {
            Repository.Remove(entity);
        }

        [HttpDelete]
        public void Remove(long id)
        {
            Repository.Remove(id);
        }

        [HttpDelete]
        public void Clear()
        {
            Repository.Clear();
        }
    }
}
