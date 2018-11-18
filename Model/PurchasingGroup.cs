using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace moneygoes.Models
{
    public class PurchasingGroup : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public List<Purchase> Purchases { get; set; } = new List<Purchase>();
        public List<AppUser> UsersInGroup { get; set; } = new List<AppUser>();
    }
}