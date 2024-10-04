using EnterpriseClientService.Domain.Entities;
using EnterpriseClientService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace EnterpriseClientService.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : Entity
    {

        protected readonly IMongoDatabase _context;
        protected readonly IMongoCollection<T> _mongoCollection;
        public ReadRepository(MongoClient mongoClient, string collectionName)
        {
            _context = mongoClient.GetDatabase("EnterpriseClientService");
            _mongoCollection = _context.GetCollection<T>(collectionName);
        }
        public async Task DeleteAsync(T entity, CancellationToken ct = default) => await _mongoCollection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", entity.Id), ct);
        public async Task InsertAsync(T entity, CancellationToken ct = default) => await _mongoCollection.InsertOneAsync(entity, ct);
        public async Task<T?> GetAsync(Guid id, CancellationToken ct = default) => await _mongoCollection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync(ct);
        public async Task UpdateAsync(T entity, CancellationToken ct = default) => await _mongoCollection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", entity.Id), entity, cancellationToken: ct);
        public async Task<List<T>?> GetAllAsync(CancellationToken ct = default) => await _mongoCollection.Find(Builders<T>.Filter.Empty).ToListAsync(ct);
    }
}
