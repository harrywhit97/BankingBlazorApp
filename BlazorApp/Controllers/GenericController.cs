using Domain.Abstract;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Repositories;
using System.Collections.Generic;

namespace Domain.Controllers
{
    [ApiController]
    public abstract class GenericController<TEntity> : ControllerBase where TEntity : Entity
    {
        public IRepository<TEntity> Repository { get; }

        public GenericController(UnitOfWork unitOfWork)
        {
            Repository = unitOfWork.GetRepoInstance<TEntity>();
        }

        // GET: api/pressureReadings
        [HttpGet("api/{controller}")]
        public IList<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        [HttpGet("api/{controller}/{id}")]
        public TEntity Get(long id)
        {
            return Repository.Get(id);
        }
    }
}
