using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_A1_EDROU21600.Pages
{
    public class ContactModel : PageModel
    {

        [BindProperty]
        [Required (ErrorMessage ="First Name is Blank")]
        public string FirstName { get; set; } = "";
        [BindProperty]
		[Required(ErrorMessage = "Last Name is Blank")]
		public string LastName { get; set; } = "";
        [BindProperty]
		[Required(ErrorMessage = "Email is Blank")]
		public string Email { get; set; } = "";
        [BindProperty]
        public string? PhoneNumber { get; set; } = "";

        [BindProperty]
		[Required(ErrorMessage = "Content is Blank")]
		public string Message { get; set; } = "";
        [BindProperty]
        public string? Location { get; set; } = "";

        public string successMessage = "";
        public string errorMessage = "";
        
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Validating Data failed";
                return;
            }

            successMessage = "Your matter has been recieved completely ";
            FirstName = "";
            LastName = "";
            Email = "";
            PhoneNumber = "";
            Message = "";
            Location = "";

            ModelState.Clear();
        }
    }
}
