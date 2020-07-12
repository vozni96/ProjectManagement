using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ViewModel
{
    public class RegisterViewModel
    {  
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Bu parola uygun değil lütfen biraz daha zorlaştırın")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Parola Onay")]
        [Compare("Password", ErrorMessage = "İki parola uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
