using System;

namespace moneygoes.Models.ViewModels
{
    public class PurchaseObjectVM : IViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created { get; set; }
    }
}