using AutoMapper;
using Domain.Commons.IRepository;
using Infra.Ef.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef.Repository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDBContext _context;
        protected readonly IMapper _mapper;
        public EfRepository(AppDBContext context, IMapper mapper)
        {          
            this._context = context;
            this._mapper = mapper;
        }

        public IQueryable<TEntity> FindAllAsync()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
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
            _context.Set<TEntity>().Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> InsertAsync(TEntity obj)
        {
            await _context.Set<TEntity>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            _context.Set<TEntity>().Update(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public void EntityStateDetached(TEntity obj)
        {
            if (obj != null)
            {
                _context.Entry(obj).State = EntityState.Detached;
            }
        }
    }
}
