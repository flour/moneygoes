using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace moneygoes.Services
{
    public interface IRepository : IDisposable
    {
        Task Delete<T>(string Id) where T : class, new();
        Task DeleteAll<T>() where T : class, new();
        Task<T> Single<T>(string Id) where T : class, new();
        Task<IEnumerable<T>> All<T>() where T : class, new();
        Task<IEnumerable<T>> All<T>(int page, int pageSize) where T : class, new();
        Task Add<T>(T item) where T : class, new();
        Task Add<T>(IEnumerable<T> items) where T : class, new();
    }
}