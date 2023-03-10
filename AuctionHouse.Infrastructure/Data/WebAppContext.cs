using AuctionHouse.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuctionHouse.Infrastructure.Data
{
    /// <summary>
    /// WebAppContext
    /// </summary>
    public class WebAppContext : IdentityDbContext<AppUser>
    {
        public WebAppContext(DbContextOptions<WebAppContext> options): base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
