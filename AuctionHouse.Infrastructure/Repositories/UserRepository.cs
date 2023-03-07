using AuctionHouse.Core.Entities;
using AuctionHouse.Core.Repositories;
using AuctionHouse.Infrastructure.Data;
using AuctionHouse.Infrastructure.Repositories.Base;

namespace AuctionHouse.Infrastructure.Repositories
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        private readonly WebAppContext _dbcontext;

        public UserRepository(WebAppContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
