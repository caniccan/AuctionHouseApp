using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    /// <summary>
    /// OrderContextSeed
    /// </summary>
    public class OrderContextSeed
    {
        /// <summary>
        /// Adds seed data
        /// </summary>
        /// <param name="orderContext"></param>
        /// <returns></returns>
        public static async Task SeedAsync(OrderContext orderContext)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// GetPreconfiguredOrders
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>()
            {
                new Order()
                {
                    AuctionId=Guid.NewGuid().ToString(),
                    ProductId=Guid.NewGuid().ToString(),
                    SellerUserName="test@test.com",
                    UnitPrice=10,
                    TotalPrice=1000,
                    CreatedAt=DateTime.Now,
                },
                new Order()
                {
                    AuctionId=Guid.NewGuid().ToString(),
                    ProductId=Guid.NewGuid().ToString(),
                    SellerUserName="test1@test.com",
                    UnitPrice=10,
                    TotalPrice=1000,
                    CreatedAt=DateTime.Now,
                },
                new Order()
                {
                    AuctionId=Guid.NewGuid().ToString(),
                    ProductId=Guid.NewGuid().ToString(),
                    SellerUserName="test2@test.com",
                    UnitPrice=10,
                    TotalPrice=1000,
                    CreatedAt=DateTime.Now,
                }
            };
        }
    }
}
