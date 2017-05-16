using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DuneBuggy.Datalayer.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Delete(T item);

        T GetSingle(Expression<Func<T, bool>> criteria);
        T GetSingle(Expression<Func<T, bool>> criteria, string[] includes);

        IEnumerable<T> GetMultiple(Expression<Func<T, bool>> criteria);
        IEnumerable<T> GetMultiple(Expression<Func<T, bool>> criteria, string[] includes);

        IEnumerable<T> GetAll();        
    }
}
