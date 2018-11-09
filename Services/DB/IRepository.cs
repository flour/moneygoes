
using System.Collections.Generic;
using System.Threading.Tasks;

namespace moneygoes.Services.DB
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetItemByIDAsync(int id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync();
        Task RemoveItemByIDAsync(int id);
        Task RemoveItemAsync(T entity);
        Task<T> AddItemAsync(T item);
        Task<T> UpdateItemAsync(T item);
        Task<bool> SaveAsync();
    }
}
