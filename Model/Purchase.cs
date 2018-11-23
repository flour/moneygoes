using System;

namespace moneygoes.Models
{
    public class Purchase : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Value { get; set; } = 0m;
        public bool Income { get; set; }
        public bool IsPlanned { get; set; }
        public bool Desired { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public int? PurchaseObjectId { get; set; }
        public PurchaseObject Object { get; set; }

        public PurchasingGroup Group { get; set; }
    }
}