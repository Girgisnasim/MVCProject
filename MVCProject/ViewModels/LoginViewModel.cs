using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PAssword { get; set; }

        public bool RememberMe { get; set; }
    }
}
