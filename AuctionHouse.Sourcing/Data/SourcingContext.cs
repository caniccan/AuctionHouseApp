﻿using AuctionHouse.Sourcing.Data.Interface;
using AuctionHouse.Sourcing.Entities;
using AuctionHouse.Sourcing.Settings;
using MongoDB.Driver;

namespace AuctionHouse.Sourcing.Data
{
    public class SourcingContext : ISourcingContext
    {
        public SourcingContext(ISourcingDatabaseSettings settings)
        {
            var client=new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Auctions = database.GetCollection<Auction>(nameof(Auction));
            Bids = database.GetCollection<Bid>(nameof(Bid));
        }

        public IMongoCollection<Auction> Auctions { get; }

        public IMongoCollection<Bid> Bids { get; }
    }
}
