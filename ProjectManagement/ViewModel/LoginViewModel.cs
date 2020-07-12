using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }
        

        [Display(Name = "Beni Hatırla?")]
        public bool RememberMe { get; set; }
    }
}
