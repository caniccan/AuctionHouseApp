using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuctionHouse.Sourcing.Entities
{
    public class Bid
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string AuctionId { get; set; }
        public string ProductId { get; set; }
        public string SellerUserName { get; set; }
        public string Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
