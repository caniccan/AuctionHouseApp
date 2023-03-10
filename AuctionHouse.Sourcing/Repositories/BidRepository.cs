using AuctionHouse.Sourcing.Data.Interface;
using AuctionHouse.Sourcing.Entities;
using AuctionHouse.Sourcing.Repositories.Interfaces;
using MongoDB.Driver;

namespace AuctionHouse.Sourcing.Repositories
{
    /// <summary>
    /// BidRepository
    /// </summary>
    public class BidRepository : IBidRepository
    {
        /// <summary>
        /// SourcingContext
        /// </summary>
        private readonly ISourcingContext _context;

        /// <summary>
        /// BidRepository Constructor
        /// </summary>
        /// <param name="context"></param>
        public BidRepository(ISourcingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GetBidsByAuctionId Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Bid>> GetBidsByAuctionId(string id)
        {
            FilterDefinition<Bid> filter = Builders<Bid>.Filter.Eq(x => x.AuctionId, id);
            List<Bid> bids = await _context.Bids.Find(filter).ToListAsync();
            bids = bids.OrderByDescending(x => x.CreatedAt).GroupBy(x => x.SellerUserName).Select(x => new Bid
            {
                AuctionId = x.FirstOrDefault().AuctionId,
                Price = x.FirstOrDefault().Price,
                CreatedAt = x.FirstOrDefault().CreatedAt,
                SellerUserName = x.FirstOrDefault().SellerUserName,
                ProductId = x.FirstOrDefault().ProductId,
                Id = x.FirstOrDefault().Id
            }).ToList();

            return bids;
        }

        /// <summary>
        /// GetWinnerBid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Bid> GetWinnerBid(string id)
        {
            List<Bid> bids=await GetBidsByAuctionId(id);

            return bids.OrderByDescending(x => x.Price).FirstOrDefault();

        }

        /// <summary>
        /// SendBid
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public async Task SendBid(Bid bid)
        {
            await _context.Bids.InsertOneAsync(bid);
        }
    }
}
