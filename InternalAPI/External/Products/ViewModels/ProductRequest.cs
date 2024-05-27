namespace API.External.Products.ViewModels
{
    public class ProductRequest
    {
        public required string Name { get; set; }

        public List<ProductTagRequest> Tags { get; set; } = [];
    }
}
