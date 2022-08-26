using Microsoft.EntityFrameworkCore;
using PRUEBA.BACKEND.DOMAIN.Interfaces;
using PRUEBA.BACKEND.INFRA.REPOSITORY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.INFRA.REPOSITORY.Services
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DBContexto context;
        protected readonly DbSet<TEntity> Entity;
        public GenericRepository(DBContexto context)
        {
            this.context = context;
            this.Entity = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await Entity.AddAsync(entity);
        }
        public void Remove(TEntity entity)
        {
            Entity.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            Entity.Update(entity);
        }
        public async Task<List<TEntity>> GetAll()
        {
            return await Entity.AsNoTracking().ToListAsync();
        }
        public async Task<TEntity?> GetAsync(int id)
        {
            return await Entity.FindAsync(id);
        }
        public async Task<TEntity?> GetAsync(long id)
        {
            return await Entity.FindAsync(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
