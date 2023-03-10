using AuctionHouse.Sourcing.Data.Interface;
using AuctionHouse.Sourcing.Entities;
using AuctionHouse.Sourcing.Settings;
using MongoDB.Driver;

namespace AuctionHouse.Sourcing.Data
{
    /// <summary>
    /// SourcingContext
    /// </summary>
    public class SourcingContext : ISourcingContext
    {
        /// <summary>
        /// SourcingContext Constructor
        /// </summary>
        /// <param name="settings"></param>
        public SourcingContext(ISourcingDatabaseSettings settings)
        {
            var client=new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Auctions = database.GetCollection<Auction>(nameof(Auction));
            Bids = database.GetCollection<Bid>(nameof(Bid));

            SourcingContextSeed.SeedData(Auctions);
        }

        /// <summary>
        /// Auctions
        /// </summary>
        public IMongoCollection<Auction> Auctions { get; }

        /// <summary>
        /// Bids
        /// </summary>
        public IMongoCollection<Bid> Bids { get; }
    }
}
