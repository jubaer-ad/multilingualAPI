using Microsoft.EntityFrameworkCore;
using MLIMS.Data;

namespace MLIMS.Repositories
{
    public abstract class Repository<T> where T : class
    {
        private readonly MLIMSDbContext _ctx;

        protected Repository(MLIMSDbContext ctx)
        {
            _ctx = ctx;
        }

        public virtual async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            _ctx.Set<T>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _ctx.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
