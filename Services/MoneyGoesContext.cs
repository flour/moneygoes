using System.Diagnostics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using moneygoes.Models;

namespace moneygoes.Services
{
    public class MoneyGoesContext : IdentityDbContext<AppUser>
    {
        public DbSet<PaymentGroup> Groups { get; set; }
        public DbSet<PaymentItem> Items { get; set; }

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