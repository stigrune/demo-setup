namespace Core.Products.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public string ExternalProductKey { get; set; } = string.Empty;  

        public ICollection<ProductTagEntity> Tags { get; set; } = [];
    }
}
