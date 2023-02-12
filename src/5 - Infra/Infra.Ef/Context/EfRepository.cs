using Domain.Commons.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef.Context
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        public EfRepository(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> FindAllAsync()
        {
            return context.Set<TEntity>().AsQueryable();
        }
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ListAsync(Func<TEntity, bool> expression, int count, int skype)
        {
            var queryable = FindAllAsync();
            queryable.Where(expression);
            queryable.Take(count);
            queryable.Take(skype);
            return await queryable.ToListAsync();
        }

        public async Task DeleteAsync(TEntity obj)
        {
            this.context.Set<TEntity>().Remove(obj);
            await this.context.SaveChangesAsync();
        }

        public async Task<TEntity> InsertAsync(TEntity obj)
        {
            await context.Set<TEntity>().AddAsync(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            context.Set<TEntity>().Update(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public void EntityStateDetached(TEntity obj)
        {
            if (obj != null)
            {
                context.Entry(obj).State = EntityState.Detached;
            }
        }
    }
}
