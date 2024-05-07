using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIProductData.Data;
using APIProductData.Models;

namespace APIProductData.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbDataAccess _dataAccess;

        public ProductRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _dataAccess.GetDataAsync<Product, dynamic>(
                "dbo.spProduct_GetAll", new { });
        }

        public async Task<Product> GetProductByIdAsyn(int id)
        {
            var product = await _dataAccess.GetDataAsync<Product, dynamic>(
                "dbo.spProducts_GetById", new { Id = id });

            return product.FirstOrDefault();
        }

        public async Task AddProductAsync(Product product)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spProduct_Insert",
                new { product.Name, product.Price });
        }

        public async Task EditProductAsync(Product product)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spProduct_Update", product);
        }

        public async Task DeleteProductAsyc(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spProduct_Delete", new { Id = id });
        }
    }
}
