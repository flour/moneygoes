using System.Diagnostics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using moneygoes.Models;

namespace moneygoes.Services
{
    public class MoneyGoesContext : IdentityDbContext<AppUser>
    {
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseObject> Goods { get; set; }
        public DbSet<PurchasingGroup> Groups { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public MoneyGoesContext(DbContextOptions<MoneyGoesContext> options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}