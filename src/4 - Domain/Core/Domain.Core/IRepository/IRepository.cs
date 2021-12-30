using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.core.IRepository
{
    public interface IRepository<T>
    {
        List<T> GetById(int id);

        List<T> GetAll(Func<T, bool> expression , int count, int skype);

        T Insert(T obj);

        T Update(T obj);

        void Delete(T obj);

        void SaveChanges();

    }
}
