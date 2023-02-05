using AuctionHouse.Sourcing.Entities;
using MongoDB.Driver;

namespace AuctionHouse.Sourcing.Data.Interface
{
    public interface ISourcingContext
    {
        IMongoCollection<Auction> Auctions { get; }
        IMongoCollection<Bid> Bids { get; }
    }
}
