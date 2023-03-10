using AuctionHouse.Products.Data.Interfaces;
using AuctionHouse.Products.Entities;
using AuctionHouse.Products.Repositories.Interfaces;
using MongoDB.Driver;

namespace AuctionHouse.Products.Repositories
{
    /// <summary>
    /// ProductRepository
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// IProductContext
        /// </summary>
        private readonly IProductContext _context;

        /// <summary>
        /// ProductRepository Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProductRepository(IProductContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            var filter=Builders<Product>.Filter.Eq(m=>m.Id,id);
            DeleteResult deleteResult =await _context.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount> 0;
        }

        /// <summary>
        /// GetProduct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetProduct(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// GetProductByCategory
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }

        /// <summary>
        /// GetProductByName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(p=>true).ToListAsync();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> Update(Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount> 0;
        }
    }
}
