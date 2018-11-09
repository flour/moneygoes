using System;

namespace moneygoes.Models
{
    public class PaymentItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Value { get; set; } = 0m;
        public bool Income { get; set; }
        public bool IsPlanned { get; set; }
        public bool Desired { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public int GroupId { get; set; }
        public PaymentGroup Group { get; set; }
    }
}