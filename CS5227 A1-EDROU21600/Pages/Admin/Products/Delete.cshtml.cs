using CS5227_A1_EDROU21600.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_A1_EDROU21600.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {
		private readonly IWebHostEnvironment environment;
		private readonly ApplicationDBcontext context;

		public DeleteModel(IWebHostEnvironment environment, ApplicationDBcontext context)
        {
			this.environment = environment;
			this.context = context;
		}
        public void OnGet(int? Id)
        {
            if (Id == null)
            {
                Response.Redirect("/Admin/Products/Index1");
                return;
            }
            var product = context.Products.Find(Id);
            if (product == null)
            {
                Response.Redirect("/Admin/Products/Index1");
                return;
            }
            string imageFullPath = environment.WebRootPath + "/ProductPics/" + product.ImageFileName;
            System.IO.File.Delete(imageFullPath);

            context.Products.Remove(product);
            context.SaveChanges();

            Response.Redirect("/Admin/Products/Index1");
        }
    }
}
