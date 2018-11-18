using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace moneygoes.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        [NotMapped]
        public List<PurchasingGroup> UsersInGroup { get; set; } = new List<PurchasingGroup>();  
    }
}