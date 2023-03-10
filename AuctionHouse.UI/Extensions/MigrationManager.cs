using AuctionHouse.Infrastructure.Data;

namespace AuctionHouse.UI.Extensions
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
        public static IHost UseMigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services= scope.ServiceProvider;
                var loggerFactory= services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var dotNetRunContext = services.GetRequiredService<WebAppContext>();
                    WebAppContextSeed.SeedAsync(dotNetRunContext,loggerFactory).Wait();
                }
                catch (Exception exception)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(exception,"An error occured seeding the DB");
                }
            }
            return host;
        }
    }
}
