using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
