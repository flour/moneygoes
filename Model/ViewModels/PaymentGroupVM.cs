using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace moneygoes.Models.ViewModels
{
    public class PaymentGroupVM : IViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PaymentItemVM> Items { get; set; } = new List<PaymentItemVM>();
    }
}
