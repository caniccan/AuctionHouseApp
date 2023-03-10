using AuctionHouse.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse.Infrastructure.Data
{
    /// <summary>
    /// WebAppContextSeed
    /// </summary>
    public class WebAppContextSeed
    {
        /// <summary>
        /// Adds seed data
        /// </summary>
        /// <param name="webAppContext"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="retry"></param>
        /// <returns></returns>
        public static async Task SeedAsync(WebAppContext webAppContext, ILoggerFactory loggerFactory, int? retry=0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                webAppContext.Database.Migrate();
                if (!webAppContext.AppUsers.Any())
                {
                    webAppContext.AppUsers.AddRange(GetPreconfiguredOrders());
                    await webAppContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    var log =loggerFactory.CreateLogger<WebAppContextSeed>();
                    log.LogError(exception.Message);
                    Thread.Sleep(2000);
                    await SeedAsync(webAppContext,loggerFactory,retryForAvailability);
                }
            }
        }

        /// <summary>
        /// GetPreconfiguredOrders
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<AppUser> GetPreconfiguredOrders()
        {
            return new List<AppUser>()
            {
                new AppUser
                {
                    FirstName="User1",
                    LastName="User LastName1",
                    IsSeller=true,
                    IsBuyer=false,
                }
            };
        }
    }
}
