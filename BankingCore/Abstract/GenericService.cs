using Domain.Abstract;
using System.Collections.Generic;
using Newtonsoft.Json;
using FluentValidation;

namespace BankingCore.Abstract
{

    //TODO: remove services and replace with comproller api requests form UI
    public class GenericService<TEntity, TValidator> where TEntity : Entity where TValidator : AbstractValidator<TEntity>
    {
        GenericController<TEntity, TValidator> Controller;

        public GenericService(GenericController<TEntity, TValidator> controller)
        {
            Controller = controller;
        }

        public void Add(TEntity entity) => Controller.Add(entity);
        public IEnumerable<TEntity> GetAll() => Controller.GetAll();
        public void Remove(TEntity entity) => Controller.Remove(entity);
        public void Clear() => Controller.Clear();

        public TEntity Clone(TEntity o)
        {
            var serializedObject = JsonConvert.SerializeObject(o);
            return JsonConvert.DeserializeObject<TEntity>(serializedObject);
        }
    }
}
