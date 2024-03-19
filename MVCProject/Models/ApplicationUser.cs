using Microsoft.AspNetCore.Identity;

namespace MVCProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
