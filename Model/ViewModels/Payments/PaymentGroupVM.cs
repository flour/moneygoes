using System.ComponentModel.DataAnnotations;

namespace moneygoes.Models.ViewModels
{
    public class PaymentGroupVM
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string UserId { get; set; }

    }
}
