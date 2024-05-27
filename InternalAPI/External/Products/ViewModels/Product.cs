namespace API.External.Products.ViewModels
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string ExternalProductKey { get; set; } = string.Empty;

        public List<ProductTag> Tags { get; set; } = [];
    }
}
