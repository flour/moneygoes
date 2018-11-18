using System;

namespace moneygoes.Models
{
    public class PurchaseObject : BaseEntity
    {
        public decimal Rank { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }        
        public DateTime Created { get; set; } = DateTime.Now;
    }
}