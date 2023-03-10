using AuctionHouse.Sourcing.Entities;

namespace AuctionHouse.Sourcing.Repositories.Interfaces
{
    /// <summary>
    /// IBidRepository
    /// </summary>
    public interface IBidRepository
    {
        /// <summary>
        /// SendBid
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        Task SendBid(Bid bid);

        /// <summary>
        /// GetBidsByAuctionId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<Bid>> GetBidsByAuctionId(string id);

        /// <summary>
        /// GetWinnerBid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Bid> GetWinnerBid(string id);
    }
}
