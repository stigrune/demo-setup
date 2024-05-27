namespace Core.Products.Entities
{
    public class ProductTagEntity
    {
        public int Id { get; set; }
        public required string Tag { get; set; }
        public required string Image { get; set; }
    }
}
