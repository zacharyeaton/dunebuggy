using DuneBuggy.Datalayer.UnitOfWork;
using DuneBuggy.Businesslayer.Models;

namespace DuneBuggy.Datalayer.Repository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
