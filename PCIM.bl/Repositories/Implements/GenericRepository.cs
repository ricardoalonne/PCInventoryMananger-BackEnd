using PCIM.dat;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PCIMContext pcimContext;

        public GenericRepository(PCIMContext pcimContext)
        {
            this.pcimContext = pcimContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            pcimContext.Set<TEntity>().Remove(entity);
            await pcimContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await pcimContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await pcimContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            pcimContext.Set<TEntity>().Add(entity);
            await pcimContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //pcimContext.Entry(entity).State = EntityState.Modified;
            pcimContext.Set<TEntity>().AddOrUpdate(entity);
            await pcimContext.SaveChangesAsync();
            return entity;
        }
    }
}
