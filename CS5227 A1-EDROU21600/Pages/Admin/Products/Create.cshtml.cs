using CS5227_A1_EDROU21600.Data;
using CS5227_A1_EDROU21600.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_A1_EDROU21600.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDBcontext context;

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();

        public CreateModel(IWebHostEnvironment environment, ApplicationDBcontext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {
        }

        public string errorMessage = "";
        public string successMessage = "";

        public void OnPost() { 
            if (this.ProductDto.ImageFile == null) 
            {
                ModelState.AddModelError("ProductDto.ImageFile", "The image file is required");
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the reuired fields";
                return;
            }

            string newFileName = DateTime.Now.ToString("yyMMddHHmmssfff");
            newFileName += Path.GetExtension(ProductDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/ProductPics/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                ProductDto.ImageFile.CopyTo(stream);
            }

            Product product = new Product()
            {
                Name = ProductDto.Name,
                Country = ProductDto.Country,
                Price = ProductDto.Price,
                Description = ProductDto.Description ?? "",
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,

            };

            context.Products.Add(product);
            context.SaveChanges();


            ProductDto.Name = "";
            ProductDto.Country = "";
            ProductDto.Price = 0;
            ProductDto.Description = "";
            ProductDto.ImageFile = null;
            ProductDto.ImageData = null;

            ModelState.Clear();

            successMessage = "Product created successfully";

            Response.Redirect("/Admin/Products/Index1");

        }
    }
}
