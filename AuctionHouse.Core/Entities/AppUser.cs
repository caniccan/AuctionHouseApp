using Microsoft.AspNetCore.Identity;

namespace AuctionHouse.Core.Entities
{
    /// <summary>
    /// AppUser
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// IsSeller
        /// </summary>
        public bool IsSeller { get; set; }

        /// <summary>
        /// IsBuyer
        /// </summary>
        public bool IsBuyer { get; set; }

        /// <summary>
        /// IsAdmin
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
