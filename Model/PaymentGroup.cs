using System;
using System.Collections.Generic;
namespace moneygoes.Models
{
    public class PaymentGroup : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public List<PaymentItem> Items { get; set; } = new List<PaymentItem>();
        public DateTime Created { get; set; } = DateTime.Now;
    }
}