using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Responses
{
    /// <summary>
    /// OrderResponse
    /// </summary>
    public class OrderResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// AuctionId
        /// </summary>
        public string AuctionId { get; set; }

        /// <summary>
        /// SellerUserName
        /// </summary>
        public string SellerUserName { get; set; }

        /// <summary>
        /// ProductId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// UnitPrice
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// TotalPrice
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// CreatedAt
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
