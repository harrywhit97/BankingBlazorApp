using Domain.Abstract;
using Repository.Interfaces;
using Repository.Repositories;
using System;

namespace Repository
{
    public static class RepositoryFactory
    {
        public static IRepository<TEntity> GetNewRepository<TEntity>(RepositoryType repositoryType) where TEntity : Entity
        {
            switch (repositoryType)
            {
                case RepositoryType.InMemory: 
                    return new InMemoryRepository<TEntity>();
                case RepositoryType.SQLDataBase: 
                    return new UnitOfWork().GetRepoInstance<TEntity>();
                default: throw new Exception($"'{repositoryType}' was not a recogized repository type");
            }
        }
    }
}
