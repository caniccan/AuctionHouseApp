﻿using AuctionHouse.Sourcing.Entities;
using MongoDB.Driver;

namespace AuctionHouse.Sourcing.Data
{
    /// <summary>
    /// SourcingContextSeed
    /// </summary>
    public class SourcingContextSeed
    {
        /// <summary>
        /// Adds seed data
        /// </summary>
        /// <param name="auctionCollection"></param>
        public static void SeedData(IMongoCollection<Auction> auctionCollection)
        {
            bool exist=auctionCollection.Find(p=>true).Any();
            if (!exist)
            {
                auctionCollection.InsertManyAsync(GetPreconfiguredAuctions());
            }
        }

        /// <summary>
        /// GetPreconfiguredAuctions
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Auction> GetPreconfiguredAuctions()
        {
            return new List<Auction>()
            {
                new Auction()
                {
                    Name="Auction 1",
                    Description="Auction Desc 1",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(10),
                    ProductId="60093337093d7352d5467341",
                    IncludedSellers= new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    },
                    Quantity=5,
                    Status=(int)Status.Active
                },
                new Auction()
                {
                    Name="Auction 2",
                    Description="Auction Desc 2",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(10),
                    ProductId="60093337093d7352d5467341",
                    IncludedSellers= new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    },
                    Quantity=5,
                    Status=(int)Status.Active
                },
                new Auction()
                {
                    Name="Auction 3",
                    Description="Auction Desc 3",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(10),
                    ProductId="60093337093d7352d5467341",
                    IncludedSellers= new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    },
                    Quantity=5,
                    Status=(int)Status.Active
                }
            };
        }
    }
}
