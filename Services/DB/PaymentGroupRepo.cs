using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using moneygoes.Models;

namespace moneygoes.Services.DB
{
    public interface IPaymentGroupRepo : IRepository<PurchasingGroup>
    {
    }

    public class PaymentGroupRepo : IPaymentGroupRepo
    {
        private readonly MoneyGoesContext _context;
        public PaymentGroupRepo(MoneyGoesContext context)
        {
            _context = context;
        }

        public async Task<PurchasingGroup> AddItemAsync(PurchasingGroup item)
            => (await _context.Groups.AddAsync(item)).Entity;

        public async Task<PurchasingGroup> GetItemAsync(string id)
            => await _context.Groups.FindAsync(id);

        public async Task<PurchasingGroup> GetItemByIDAsync(int id)
            => await _context.Groups.FindAsync(id);

        public async Task<IEnumerable<PurchasingGroup>> GetItemsAsync()
            => await _context.Groups.ToListAsync();

        public Task RemoveItemAsync(PurchasingGroup entity)
        {
            _context.Groups.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task RemoveItemByIDAsync(int id)
        {
            var entity = await GetItemByIDAsync(id);
            _context.Groups.Remove(entity);
        }

        public async Task<bool> SaveAsync()
            => await _context.SaveChangesAsync() >= 0;

        public Task<PurchasingGroup> UpdateItemAsync(PurchasingGroup item)
        {
            var result = _context.Update(item).Entity;
            return Task.FromResult(result);
        }
    }
}