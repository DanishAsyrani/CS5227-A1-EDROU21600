using CS5227_A1_EDROU21600.Data;
using CS5227_A1_EDROU21600.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace CS5227_A1_EDROU21600.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDBcontext context;

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();
        public Product Product { get; set; } = new Product();

        public string errorMessage = "";
        public string successMessage = "";
        public EditModel(IWebHostEnvironment environment, ApplicationDBcontext context)
        {
            this.environment = environment; 
            this.context = context;

        }
        public void OnGet(int? Id)
        {
            if(Id == null)
            {
                Response.Redirect("/Admin/Products/Index1");
                return;
            }
            var product = context.Products.Find(Id);
            if(product == null)
            {
                Response.Redirect("/Admin/Products/Index1");

            }

        }
    }
}
