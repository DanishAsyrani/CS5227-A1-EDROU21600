using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
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

        public PageResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Validating Data failed";
				return Page();
            }

            successMessage = "Your matter has been recieved completely ";
            FirstName = "";
            LastName = "";
            Email = "";
            PhoneNumber = "";
            Message = "";
            Location = "";

            ModelState.Clear();
            try
            {
				var fromAddress = new MailAddress("5705@laksamanacollege.edu.bn", "Danish");
                var toAddress = new MailAddress("edrousdanish@gmail.com", "Recipient Name");
                const string fromPassword = "Enish544";
                const string subject = "Contact Form Submission";
                string body = $"Name: {FirstName} \nEmail : {Email} \nMessage: {Message}";

                var smtp = new SmtpClient
                {
                    Host = "localhost",
                    Port = 7018,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

				using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                })
                {
                    smtp.Send(message);
                }

			} 
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occured while sending your message, Please try again later.");
                return Page();
            }
            return Page();






		}
        
	}
}
