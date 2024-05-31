using CS5227_A1_EDROU21600.Data;
using CS5227_A1_EDROU21600.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_A1_EDROU21600.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly ApplicationDBcontext _context;

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public decimal Total { get; set; }

        public CheckoutModel(ApplicationDBcontext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Load cart items from session or database
            // This is just a placeholder. Replace with your actual cart logic.
            CartItems = new List<CartItem>
            {
                new CartItem { ProductName = "Product 1", Quantity = 2, Price = 19.99m },
                new CartItem { ProductName = "Product 2", Quantity = 1, Price = 9.99m }
            };

            Total = CartItems.Sum(item => item.Subtotal);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Process the order
            foreach (var item in CartItems)
            {
                var sale = new Sale
                {
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Subtotal = item.Subtotal,
                    PurchaseDate = DateTime.UtcNow
                };
                _context.Sale.Add(sale);
            }
            await _context.SaveChangesAsync();

            // Clear the cart
            // This is just a placeholder. Replace with your actual cart clearing logic.
            CartItems.Clear();

            return RedirectToPage("/OrderConfirmation");
        }

        public class CartItem
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal Subtotal => Quantity * Price;
        }
    }
}
