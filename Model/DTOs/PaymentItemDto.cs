using System;

namespace moneygoes.Models.DTOs
{
    public class PaymentItemDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Value { get; set; } = 0m;
        public bool Income { get; set; }
        public bool IsPlanned { get; set; }
        public bool Desire { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}