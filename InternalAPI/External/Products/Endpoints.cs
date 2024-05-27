using API.External.Products.ViewModels;
using Core.Products;
using Core.Products.Entities;
using Microsoft.AspNetCore.Mvc;


namespace API.External.Products
{
    public static class Endpoints
    {
        public static void RegisterProductsEndpoints(this IEndpointRouteBuilder routes)
        {
            var products = routes
                .MapGroup("products")
                .WithTags("products");
           
            products.MapGet("/", GetAllProducts)
                .WithName("GetProducts")
                .WithOpenApi();

            products.MapPost("/products", PostProduct)
                 .WithName("InsertProduct")
                 .WithOpenApi();

            products.MapGet("/products/availability", CheckAvailability)
             .WithName("CheckAvailability")
             .WithOpenApi();
        }

        private static async Task<Product> PostProduct(
            [FromServices] IProductService productService,
            [FromBody] ProductRequest productRequest,
            CancellationToken cancellationToken)
        {
            var mapped = new ProductEntity { Name = productRequest.Name, Tags = productRequest.Tags.Select(t => new ProductTagEntity { Tag = t.Tag, Image = t.Image }).ToArray() };
            var response = await productService.Insert(mapped, cancellationToken);
            return response.MapProduct();
        }

        private static async Task<ICollection<Product>> GetAllProducts(
            [FromServices] IProductService productService,
            CancellationToken cancellationToken)
        {
            var products = await productService.GetProducts(cancellationToken);

            return products.Select(p => p.MapProduct()).ToList();
        }

        private static async Task<bool> CheckAvailability(
            [FromServices] IProductService productService,
            [FromQuery] string productKey,
            [FromQuery] string instance,
            [FromQuery] int passengerCount,
            CancellationToken cancellationToken)
        {
            return await productService.CheckAvailability(productKey, instance, passengerCount, cancellationToken);
        }

        // TODO Mapperly
        private static Product MapProduct(this ProductEntity source)
        {
            return new Product
            {
                Name = source.Name,
                Id = source.Id,
                Tags = source.Tags.Select(t => new ProductTag { Tag = t.Tag }).ToList()
            };
        }
    }
}
