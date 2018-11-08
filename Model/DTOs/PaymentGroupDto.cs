using System;
using System.Collections.Generic;

namespace moneygoes.Models.DTOs
{
    public class PaymentGroupDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public List<PaymentItemDto> Items { get; set; } = new List<PaymentItemDto>();
        public DateTime Created { get; set; }
    }
}