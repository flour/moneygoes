using System.ComponentModel.DataAnnotations;

namespace moneygoes.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email should be set")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password should be set")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Username should be set")]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required(ErrorMessage = "First name should be set")]
        [Display(Name = "First name")]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name should be set")]
        [Display(Name = "Last name")]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}