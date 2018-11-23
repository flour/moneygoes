using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using moneygoes.Models;

namespace moneygoes.Services.DB
{
    public interface IPurchasesRepo : IRepository<Purchase>
    {
    }

    public class PurchasesRepo : IPurchasesRepo
    {
        private readonly MoneyGoesContext _context;
        public PurchasesRepo(MoneyGoesContext context)
        {
            _context = context;
        }

        public async Task<Purchase> AddItemAsync(Purchase item)
            => (await _context.Purchases.AddAsync(item)).Entity;

        public async Task<Purchase> GetItemAsync(string id)
            => await _context.Purchases.FindAsync(id);

        public async Task<Purchase> GetItemByIDAsync(int id)
            => await _context.Purchases.FindAsync(id);

        public async Task<IEnumerable<Purchase>> GetItemsAsync()
            => await _context.Purchases.ToListAsync();

        public Task RemoveItemAsync(Purchase entity)
        {
            _context.Purchases.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task RemoveItemByIDAsync(int id)
        {
            var entity = await GetItemByIDAsync(id);
            _context.Purchases.Remove(entity);
        }

        public async Task<bool> SaveAsync()
            => await _context.SaveChangesAsync() >= 0;

        public Task<Purchase> UpdateItemAsync(Purchase item)
        {
            var result = _context.Update(item).Entity;
            return Task.FromResult(result);
        }
    }
}