using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories.Base;

namespace Ordering.Infrastructure.Repositories
{
    /// <summary>
    /// OrderRepository
    /// </summary>
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        /// <summary>
        /// OrderRepository Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public OrderRepository(OrderContext dbContext): base(dbContext)
        {

        }

        /// <summary>
        /// GetOrdersBySellerUserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetOrdersBySellerUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                .Where(x => x.SellerUserName == userName).ToListAsync();
            return orderList;
        }
    }
}
