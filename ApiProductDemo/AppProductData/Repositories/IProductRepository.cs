using APIProductData.Models;

namespace APIProductData.Repositories
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsyc(int id);
        Task EditProductAsync(Product product);
        Task<Product> GetProductByIdAsyn(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}