using AuctionHouse.Sourcing.Entities;
using MongoDB.Driver;

namespace AuctionHouse.Sourcing.Data.Interface
{
    /// <summary>
    /// ISourcingContext
    /// </summary>
    public interface ISourcingContext
    {
        /// <summary>
        /// Auctions
        /// </summary>
        IMongoCollection<Auction> Auctions { get; }

        /// <summary>
        /// Bids
        /// </summary>
        IMongoCollection<Bid> Bids { get; }
    }
}
