using System.Configuration;
using System.Data.Entity.Core.Objects;
using DuneBuggy.Datalayer.Repository;
using DuneBuggy.Businesslayer.Models;

namespace DuneBuggy.Datalayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ObjectContext context;

        public UnitOfWork()
        {            
            var cs = ConfigurationManager.ConnectionStrings["DuneBuggyDbContext"];
            string connectionString = cs.ConnectionString;
            context = new ObjectContext(connectionString);
            context.ContextOptions.LazyLoadingEnabled = true;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public IObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class
        {
            return context.CreateObjectSet<TEntity>();
        }

        public bool EnableLazyLoading
        {
            get { return context.ContextOptions.LazyLoadingEnabled; }
            set { context.ContextOptions.LazyLoadingEnabled = value; }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepository<User> User => new UserRepository(this);

        public IRepository<Product> Product => new ProductRepository(this);
    }
}
