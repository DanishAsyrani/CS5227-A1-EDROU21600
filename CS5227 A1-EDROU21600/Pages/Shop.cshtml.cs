using CS5227_A1_EDROU21600.Data;
using CS5227_A1_EDROU21600.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CS5227_A1_EDROU21600.Pages
{
    public class ShopModel : PageModel
    {
        private readonly ApplicationDBcontext _context;

        public List<Product> Products { get; set; } = new List<Product>();

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }



        public ShopModel(ApplicationDBcontext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            //var query = _context.Products.AsQueryable();

            //if (!string.IsNullOrEmpty(SearchQuery))
            //{
            //    query = query.Where(p => p.Name.Contains(SearchQuery) || p.Description.Contains(SearchQuery));
            //}

            //Products = query.ToList();

            Products = string.IsNullOrEmpty(SearchQuery)
                ? _context.Products.ToList()
                : _context.Products.Where(p => p.Name.Contains(SearchQuery) || p.Description.Contains(SearchQuery)).ToList();
        }
        public IActionResult OnPostAddToCart(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var cartItem = cart.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity++;
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToPage();
        }
    }
}
