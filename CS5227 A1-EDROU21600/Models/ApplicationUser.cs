using Microsoft.AspNetCore.Identity;

namespace CS5227_A1_EDROU21600.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
