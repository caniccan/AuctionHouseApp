using Ordering.Domain.Entities;
using Ordering.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Repositories
{
    /// <summary>
    /// IOrderRepository
    /// </summary>
    public interface IOrderRepository :IRepository<Order>
    {
        /// <summary>
        /// GetOrdersBySellerUserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetOrdersBySellerUserName(string userName);
    }
}
