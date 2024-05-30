using System.Diagnostics.Metrics;
using CS5227_A1_EDROU21600.Data;
using CS5227_A1_EDROU21600.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
				return;

            }
            ProductDto.Name = product.Name;
            ProductDto.Country = product.Country;
            ProductDto.Price = product.Price;
            ProductDto.Description = product.Description;

            Product = product;

        }
        public void OnPost(int? Id)
        {
            if (Id == null)
            {
                Response.Redirect("/Admin/Products/Index1");
                return;
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var product = context.Products.Find(Id);
            if (product == null)
            {
                Response.Redirect("/Admin/Products/Index");
                return;
            }
            string newFileName = product.ImageFileName;
            if (ProductDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(ProductDto.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/ProductPics/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    ProductDto.ImageFile.CopyTo(stream); 
                }
                string oldImageFullPath = environment.WebRootPath +"/ProductPics/" + product.ImageFileName;
                System.IO.File.Delete(oldImageFullPath);    

            }
            //update product again

            product.Name = ProductDto.Name;
            product.Country = ProductDto.Country;
            product.Price = ProductDto.Price;
            product.Description = ProductDto.Description ?? "";
            product.ImageFileName = newFileName;

            context.SaveChanges();

			Product = product;
            successMessage = "Product updated successfully";
            Response.Redirect("/Admin/Products/Index1");
        }

	}
}
