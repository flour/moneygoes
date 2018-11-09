
using System.ComponentModel.DataAnnotations;

namespace moneygoes.Models.ViewModels.Account
{
    public class LoginVM : IViewModel
    {
        [Required(ErrorMessage = "Email should be set")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password should be set")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
