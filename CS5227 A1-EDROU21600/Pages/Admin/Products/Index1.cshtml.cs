using CS5227_A1_EDROU21600.Data;
using CS5227_A1_EDROU21600.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_A1_EDROU21600.Pages.Admin.Products
{
    public class Index1Model : PageModel
    {
        private readonly ApplicationDBcontext context;

        public List<Product> Products { get; set; } = new List<Product>();

        public Index1Model (ApplicationDBcontext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            Products = context.Products.OrderByDescending(p => p.Id).ToList();
        }
    }
}
