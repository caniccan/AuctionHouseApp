using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Data;

namespace AuctionHouse.Order.Extensions
{
    /// <summary>
    /// MigrationManager
    /// </summary>
    public static class MigrationManager
    {
        /// <summary>
        /// Database Migration
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var orderContext = scope.ServiceProvider.GetRequiredService<OrderContext>();

                    if (orderContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {
                        orderContext.Database.Migrate();
                    }

                    OrderContextSeed.SeedAsync(orderContext).Wait();
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
            return host;
        }
    }
}
