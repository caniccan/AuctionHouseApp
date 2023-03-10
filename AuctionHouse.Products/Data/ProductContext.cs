using AuctionHouse.Products.Data.Interfaces;
using AuctionHouse.Products.Entities;
using AuctionHouse.Products.Settings;
using MongoDB.Driver;

namespace AuctionHouse.Products.Data
{
    /// <summary>
    /// ProductContext
    /// </summary>
    public class ProductContext : IProductContext
    {
        /// <summary>
        /// ProductContext Constructor
        /// </summary>
        /// <param name="settings"></param>
        public ProductContext(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>(settings.CollectionName);
            ProductContextSeed.SeedData(Products);
        }

        /// <summary>
        /// Products
        /// </summary>
        public IMongoCollection<Product> Products { get; }
    }
}
