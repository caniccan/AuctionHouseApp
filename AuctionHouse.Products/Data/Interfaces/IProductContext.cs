using AuctionHouse.Products.Entities;
using MongoDB.Driver;

namespace AuctionHouse.Products.Data.Interfaces
{
    /// <summary>
    /// IProductContext
    /// </summary>
    public interface IProductContext
    {
        /// <summary>
        /// Products
        /// </summary>
        IMongoCollection<Product> Products { get; }
    }
}
