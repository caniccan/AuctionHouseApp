using AuctionHouse.Sourcing.Data.Interface;
using AuctionHouse.Sourcing.Entities;
using AuctionHouse.Sourcing.Repositories.Interfaces;
using MongoDB.Driver;

namespace AuctionHouse.Sourcing.Repositories
{
    /// <summary>
    /// AuctionRepository
    /// </summary>
    public class AuctionRepository : IAuctionRepository
    {
        /// <summary>
        /// ISourcingContext
        /// </summary>
        private readonly ISourcingContext _context;

        /// <summary>
        /// AuctionRepository Constructor
        /// </summary>
        /// <param name="context"></param>
        public AuctionRepository(ISourcingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="auction"></param>
        /// <returns></returns>
        public async Task Create(Auction auction)
        {
            await _context.Auctions.InsertOneAsync(auction);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(e => e.Id , id);
            DeleteResult deleteResult= await _context.Auctions.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        /// <summary>
        /// GetAuction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Auction> GetAuction(string id)
        {
            return await _context.Auctions.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// GetAuctionByName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Auction> GetAuctionByName(string name)
        {
            FilterDefinition<Auction> filter=Builders<Auction>.Filter.Eq(x => x.Name , name);

            return await _context.Auctions.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// GetAuctions
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Auction>> GetAuctions()
        {
            return await _context.Auctions.Find(x=>true).ToListAsync();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="auction"></param>
        /// <returns></returns>
        public async Task<bool> Update(Auction auction)
        {
            var updateResult = await _context.Auctions.ReplaceOneAsync(x=>x.Id.Equals(auction.Id),auction);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
