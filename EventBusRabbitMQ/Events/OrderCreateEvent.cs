using EventBusRabbitMQ.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Events
{
    /// <summary>
    /// OrderCreateEvent
    /// </summary>
    public class OrderCreateEvent: IEvent
    {
        /// <summary>
        /// Gets or Sets the Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets the AuctionId
        /// </summary>
        public string AuctionId { get; set; }

        /// <summary>
        /// Gets or Sets the ProductId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or Sets the SellerUserName
        /// </summary>
        public string SellerUserName { get; set; }

        /// <summary>
        /// Gets or Sets the Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or Sets the CreatedAt
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets the Quantity
        /// </summary>
        public int Quantity { get; set; }
    }
}
