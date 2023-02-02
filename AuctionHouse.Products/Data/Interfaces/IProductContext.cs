using AuctionHouse.Products.Entities;
using MongoDB.Driver;

namespace AuctionHouse.Products.Data.Interfaces
{
    public interface IProductContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
