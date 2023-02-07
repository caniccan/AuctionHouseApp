using AuctionHouse.Sourcing.Data.Interface;
using AuctionHouse.Sourcing.Entities;
using AuctionHouse.Sourcing.Repositories.Interfaces;
using MongoDB.Driver;

namespace AuctionHouse.Sourcing.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ISourcingContext _context;

        public AuctionRepository(ISourcingContext context)
        {
            _context = context;
        }

        public async Task Create(Auction auction)
        {
            await _context.Auctions.InsertOneAsync(auction);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(e => e.Id , id);
            DeleteResult deleteResult= await _context.Auctions.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Auction> GetAuction(string id)
        {
            return await _context.Auctions.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Auction> GetAuctionByName(string name)
        {
            FilterDefinition<Auction> filter=Builders<Auction>.Filter.Eq(x => x.Name , name);

            return await _context.Auctions.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Auction>> GetAuctions()
        {
            return await _context.Auctions.Find(x=>true).ToListAsync();
        }

        public async Task<bool> Update(Auction auction)
        {
            var updateResult = await _context.Auctions.ReplaceOneAsync(x=>x.Id.Equals(auction.Id),auction);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
