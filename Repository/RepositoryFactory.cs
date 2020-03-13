using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Interfaces;
using Repository.Repositories;
using System;

namespace Repository
{
    public static class RepositoryFactory
    {
        public static IRepository<TEntity> GetNewRepository<TEntity>(RepositoryType repositoryType, DbContext context = null) where TEntity : Entity
        {
            switch (repositoryType)
            {
                case RepositoryType.InMemory: 
                    return new InMemoryRepository<TEntity>();
                case RepositoryType.SQLDataBase:
                    if (context is null)
                        throw new Exception("An SQL database requires a DB context");
                    return new EFRepository<TEntity>(context);
                default: throw new Exception($"'{repositoryType}' was not a recogized repository type");
            }
        }
    }
}
