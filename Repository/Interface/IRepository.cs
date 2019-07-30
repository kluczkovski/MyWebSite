using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebSite.Models;

namespace MyWebSite.Repository.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(Guid id);

        Task<int> SaveChanges();

        Task<TEntity> GetById(Guid id);

        Task<IEnumerable<TEntity>> GetAll();

    }
}
