using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Commons.IRepository
{
    public interface IRepository<TEntity>
    {
        //use in reports
        IQueryable<TEntity> FindAllAsync();

        //use in grids
        Task<IEnumerable<TEntity>> ListAsync(Func<TEntity, bool> expression, int count, int skype);

        #nullable enable
        Task<TEntity?> GetByIdAsync(int id);

        Task<TEntity> InsertAsync(TEntity obj);

        Task<TEntity> UpdateAsync(TEntity obj);

        Task DeleteAsync(TEntity obj);

        void EntityStateDetached(TEntity entity);
    }
}
