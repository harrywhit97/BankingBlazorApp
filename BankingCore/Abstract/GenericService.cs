using Domain.Abstract;
using System.Collections.Generic;
using Newtonsoft.Json;
using FluentValidation;
using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace BankingCore.Abstract
{

    //TODO: remove services and replace with comproller api requests form UI
    public class GenericService<TEntity, TValidator> : IDisposable where TEntity : Entity where TValidator : AbstractValidator<TEntity>
    {
        GenericController<TEntity, TValidator> Controller;
        bool disposed;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public GenericService(GenericController<TEntity, TValidator> controller)
        {
            Controller = controller;
            disposed = false;
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                handle.Dispose();
        }
    }
}
