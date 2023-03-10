using AuctionHouse.Sourcing.Entities;

namespace AuctionHouse.Sourcing.Repositories.Interfaces
{
    /// <summary>
    /// IAuctionRepository
    /// </summary>
    public interface IAuctionRepository
    {
        /// <summary>
        /// GetAuctions
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Auction>> GetAuctions();

        /// <summary>
        /// GetAuction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Auction> GetAuction(string id);

        /// <summary>
        /// GetAuctionByName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Auction> GetAuctionByName(string name);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="auction"></param>
        /// <returns></returns>
        Task Create(Auction auction);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="auction"></param>
        /// <returns></returns>
        Task<bool> Update(Auction auction);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(string id);

    }
}
