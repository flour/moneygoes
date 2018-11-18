using System;
using System.Collections.Generic;

namespace moneygoes.Models.DTOs
{
    public class PurchasingGroupDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PurchaseDto> Items { get; set; } = new List<PurchaseDto>();
        public DateTime Created { get; set; }
    }
}