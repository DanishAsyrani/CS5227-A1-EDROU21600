using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_A1_EDROU21600.Pages
{
    [Authorize(Roles = "admin")]
    public class AdminModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
