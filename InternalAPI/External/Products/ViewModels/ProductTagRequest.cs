using System.ComponentModel.DataAnnotations;

namespace API.External.Products.ViewModels
{
    public class ProductTagRequest
    {
        [Required]
        public required string Tag { get; set; }

        [Required]
        public required string Image { get; set; }
    }
}
