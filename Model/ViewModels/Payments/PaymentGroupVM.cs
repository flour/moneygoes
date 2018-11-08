using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace moneygoes.Models.ViewModels.Payments
{
    public class PaymentGroupVM
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PaymentItemVM> Items { get; set; } = new List<PaymentItemVM>();
    }
}
