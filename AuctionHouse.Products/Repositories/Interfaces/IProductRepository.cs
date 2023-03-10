using AuctionHouse.Products.Entities;

namespace AuctionHouse.Products.Repositories.Interfaces
{
    /// <summary>
    /// IProductRepository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// GetProducts
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProducts();

        /// <summary>
        /// GetProduct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProduct(string id);

        /// <summary>
        /// GetProductByName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductByName(string name);

        /// <summary>
        /// GetProductByCategory
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task Create(Product product);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<bool> Update(Product product);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(string id);
    }
}
