using APIProductData.Models;
using APIProductData.Repositories;

namespace ApiProduct
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            // Registrar nuestros endpoints
            app.MapGet("/products", GetProducts);

            app.MapPost("/products", InsertProduct);
        }

        public static async Task<IResult> GetProducts(IProductRepository product)
        {
            try
            {
                await product.GetProductsAsync();

                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> InsertProduct(Product product, IProductRepository productRepository)
        {
            try
            {
                await productRepository.AddProductAsync(product);

                return Results.Created();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
