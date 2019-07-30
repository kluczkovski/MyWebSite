using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;
using MyWebSite.Models;
using MyWebSite.Repository.Interface;

namespace MyWebSite.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly MyDBContext context;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(MyDBContext myDBContext)
        {
            context = myDBContext;
            dbSet = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
             dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await SaveChanges();
            }
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Dispose()
        {
            context?.Dispose();
        }

    }
}
