using Domain.Abstract;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlazorApp.Abstract
{
    public class GenericService<TEntity> where TEntity : Entity
    {
        GenericController<TEntity> Controller;

        public GenericService(GenericController<TEntity> controller)
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
