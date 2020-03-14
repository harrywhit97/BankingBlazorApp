using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlazorApp.Abstract
{
    public class GenericService<TEntity> where TEntity : Entity
    {
        GenericController<TEntity> Controller;

        public GenericService(GenericController<TEntity> controller)
        {
            Controller = controller;
        }
    }
}
