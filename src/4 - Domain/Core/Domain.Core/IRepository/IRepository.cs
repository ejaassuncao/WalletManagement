using System;
using System.Collections.Generic;
namespace Domain.core.IRepository
{
    public interface IRepository<T>
    {
        List<T> FindById(int id);

        List<T> FindAll(Func<T, bool> expression , int count, int skype);

        T Insert(T obj);

        T Update(T obj);

        void Delete(T obj);

        void SaveChanges();

    }
}
