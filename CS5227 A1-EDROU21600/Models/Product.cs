using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CS5227_A1_EDROU21600.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string Country { get; set; } = "";
        [Precision(16, 2)]
        public decimal Price { get; set; }
        [MaxLength(255)]
        public string Description { get; set; } = "";
        [MaxLength(100)]
        public string ImageFileName { get; set; } = "";
        public byte[]? ImageData { get; set; }

        public DateTime CreatedAt {  get; set; }

    }
}
