using AuctionHouse.Products.Entities;
using MongoDB.Driver;

namespace AuctionHouse.Products.Data
{
    /// <summary>
    /// ProductContextSeed
    /// </summary>
    public class ProductContextSeed
    {
        /// <summary>
        /// Adds seed data.
        /// </summary>
        /// <param name="productColleciton"></param>
        public static void SeedData(IMongoCollection<Product> productColleciton)
        {
            bool existProduct=productColleciton.Find(p=>true).Any();
            if (!existProduct)
            {
                productColleciton.InsertManyAsync(GetConfigureProducts());
            }
        }

        /// <summary>
        /// GetConfigureProducts
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Product> GetConfigureProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name="Iphone 14",
                    Summary="This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description="This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.",
                    ImageFile="product-2.png",
                    Price=1950.00M,
                    Category="Smart Phone"
                },
                new Product()
                {
                    Name="Samsung 10",
                    Summary="This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description="This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.",
                    ImageFile="product-2.png",
                    Price=840.00M,
                    Category="Smart Phone"
                },
                new Product()
                {
                    Name="Huawei Plus",
                    Summary="This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description="This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.",
                    ImageFile="product-2.png",
                    Price=730.00M,
                    Category="Smart Phone"
                },
                new Product()
                {
                    Name="IphoneX",
                    Summary="This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description="This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.This is description.",
                    ImageFile="product-2.png",
                    Price=950.00M,
                    Category="Smart Phone"
                }
            };
        }
    }
}
