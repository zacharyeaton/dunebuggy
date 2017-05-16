using System;
using System.Data.Entity.Core.Objects;

namespace DuneBuggy.Datalayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        IObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class;
        bool EnableLazyLoading { get; set; }
    }
}
