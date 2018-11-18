using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace moneygoes.Models.ViewModels
{
    public class PurchasingGroupVM : IViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PurchaseVM> Items { get; set; } = new List<PurchaseVM>();
    }
}
