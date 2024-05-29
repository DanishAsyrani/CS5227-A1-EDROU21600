using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CS5227_A1_EDROU21600.Models
{
    public class ProductDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Country { get; set; } = "";
        [Required]
        public decimal Price { get; set; }
     
        public string? Description { get; set; } 
        public IFormFile? ImageFile { get; set; }
        
        public byte[]? ImageData { get; set; }
    }
}
