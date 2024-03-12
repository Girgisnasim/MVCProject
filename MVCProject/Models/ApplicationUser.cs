using Microsoft.AspNetCore.Identity;

namespace MVCProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Address { get; set; }
    }
}
