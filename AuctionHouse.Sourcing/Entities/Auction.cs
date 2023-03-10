using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuctionHouse.Sourcing.Entities
{
    /// <summary>
    /// Auction
    /// </summary>
    public class Auction
    {
        /// <summary>
        /// Auction Constructor
        /// </summary>
        public Auction()
        {
            IncludedSellers = new List<string>();
        }

        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ProductId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// StartedAt
        /// </summary>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// FinishedAt
        /// </summary>
        public DateTime FinishedAt { get; set; }

        /// <summary>
        /// CreatedAt
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// IncludedSellers
        /// </summary>
        public List<string> IncludedSellers { get; set; }
    }

    /// <summary>
    /// Status
    /// </summary>
    public enum Status
    {
        Active=0,
        Closed=1,
        Passive=2
    }
}
