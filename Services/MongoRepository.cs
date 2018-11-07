using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using moneygoes.Models.AppModel;
using MongoDB.Driver;

namespace moneygoes.Services
{
    public class MongoRepository : IRepository
    {
        private MongoConnection _settings;
        private MongoClient _client;
        private IMongoDatabase _db { get { return this._client.GetDatabase(_settings.DatabaseName); } }

        private readonly Dictionary<Type, string> _collections = new Dictionary<Type, string>();

        public MongoRepository(MongoConnection settings)
        {
            _settings = settings;
            _client = new MongoClient(settings.ConnectionString);
        }

        public async Task Delete<T>(string Id) where T : class, new()
            => await _db.GetCollection<T>(GetTypeName(typeof(T))).DeleteOneAsync(Builders<T>.Filter.Eq("_id", Id));

        public async Task DeleteAll<T>() where T : class, new()
            => await _db.GetCollection<T>(GetTypeName(typeof(T))).DeleteManyAsync(Builders<T>.Filter.Empty);

        public async Task<T> Single<T>(string Id) where T : class, new()
        {
            var result = await _db.GetCollection<T>(GetTypeName(typeof(T))).FindAsync(Builders<T>.Filter.Eq("_id", Id));
            return await result.SingleOrDefaultAsync();
        }

        public async Task<T> Single<T>(string fieldName, string value) where T : class, new()
        {
            var result = await _db.GetCollection<T>(GetTypeName(typeof(T))).FindAsync(Builders<T>.Filter.Eq(fieldName, value));
            return await result.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> All<T>() where T : class, new()
            => await (await _db.GetCollection<T>(GetTypeName(typeof(T))).FindAsync(Builders<T>.Filter.Empty)).ToListAsync();

        public async Task<IEnumerable<T>> All<T>(int page, int pageSize) where T : class, new()
            => await _db.GetCollection<T>(GetTypeName(typeof(T)))
                .Find(Builders<T>.Filter.Empty)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

        public async Task Add<T>(T item) where T : class, new()
            => await _db.GetCollection<T>(GetTypeName(typeof(T))).InsertOneAsync(item);

        public async Task Add<T>(IEnumerable<T> items) where T : class, new()
            => await _db.GetCollection<T>(GetTypeName(typeof(T))).InsertManyAsync(items);

        public void Dispose()
        {
            try
            {
                _db.Client.Cluster.Dispose();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private string GetTypeName(Type type)
        {
            var result = string.Empty;
            if (!_collections.TryGetValue(type, out result))
            {
                result = type.Name;
                _collections.TryAdd(type, type.Name);
            }
            return result;
        }
    }
}