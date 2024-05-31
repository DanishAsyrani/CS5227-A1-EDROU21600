using System.ComponentModel.DataAnnotations;

namespace CS5227_A1_EDROU21600.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; } = "";

        public int Quantity { get; set; }

        public decimal Subtotal { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
