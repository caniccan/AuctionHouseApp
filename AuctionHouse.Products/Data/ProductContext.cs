﻿using AuctionHouse.Products.Data.Interfaces;
using AuctionHouse.Products.Entities;
using AuctionHouse.Products.Settings;
using MongoDB.Driver;

namespace AuctionHouse.Products.Data
{
    public class ProductContext : IProductContext
    {
        public ProductContext(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>(settings.CollectionName);
            ProductContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
