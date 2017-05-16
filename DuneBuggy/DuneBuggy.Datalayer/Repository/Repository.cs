using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using DuneBuggy.Datalayer.UnitOfWork;

namespace DuneBuggy.Datalayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IObjectSet<T> ObjectSet;        

        public Repository(IUnitOfWork unitOfWork)
        {
            ObjectSet = unitOfWork.CreateObjectSet<T>();
        }

        public void Add(T item)
        {
            ObjectSet.AddObject(item);
        }

        public void Delete(T item)
        {
            ObjectSet.DeleteObject(item);
        }

        public T GetSingle(Expression<Func<T, bool>> criteria)
        {
            return ObjectSet.Where(criteria).FirstOrDefault();
        }

        public T GetSingle(Expression<Func<T, bool>> criteria, string[] includes)
        {
            ObjectQuery<T> query = (ObjectSet<T>)ObjectSet;

            foreach (var include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(criteria);
        }

        public IEnumerable<T> GetMultiple(Expression<Func<T, bool>> criteria)
        {
            ObjectQuery<T> query = (ObjectSet<T>)ObjectSet;
            return query.Where(criteria);
        }

        public IEnumerable<T> GetMultiple(Expression<Func<T, bool>> criteria, string[] includes)
        {
            ObjectQuery<T> query = (ObjectSet<T>)ObjectSet;

            foreach (var include in includes)
                query = query.Include(include);

            return query.Where(criteria);
        }

        public IEnumerable<T> GetAll()
        {
            return ObjectSet;
        }       
    }
}
