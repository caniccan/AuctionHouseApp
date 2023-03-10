using AuctionHouse.Core.Entities;
using AuctionHouse.Core.Repositories;
using AuctionHouse.Infrastructure.Data;
using AuctionHouse.Infrastructure.Repositories.Base;

namespace AuctionHouse.Infrastructure.Repositories
{
    /// <summary>
    /// UserRepository
    /// </summary>
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        /// <summary>
        /// WebAppContext
        /// </summary>
        private readonly WebAppContext _dbcontext;

        /// <summary>
        /// UserRepository Constructor
        /// </summary>
        /// <param name="dbcontext"></param>
        public UserRepository(WebAppContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
