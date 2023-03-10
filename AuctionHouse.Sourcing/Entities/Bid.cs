using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuctionHouse.Sourcing.Entities
{
    /// <summary>
    /// Bid
    /// </summary>
    public class Bid
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// AuctionId
        /// </summary>
        public string AuctionId { get; set; }

        /// <summary>
        /// ProductId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// SellerUserName
        /// </summary>
        public string SellerUserName { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// CreatedAt
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
