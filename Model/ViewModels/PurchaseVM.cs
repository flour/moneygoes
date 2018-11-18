namespace moneygoes.Models.ViewModels
{
    public class PurchaseVM : IViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Value { get; set; } = 0m;
        public bool Income { get; set; }
        public bool IsPlanned { get; set; }
        public bool Desired { get; set; }
    }
}