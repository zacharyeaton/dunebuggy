using DuneBuggy.Datalayer.UnitOfWork;
using DuneBuggy.Businesslayer.Models;

namespace DuneBuggy.Datalayer.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
