using EnterpriseClientService.Domain.Entities;

namespace EnterpriseClientService.Domain.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : Entity
    {
        Task DeleteAsync(T entity, CancellationToken ct = default);
        Task InsertAsync(T entity, CancellationToken ct = default);
        Task<T?> GetAsync(Guid id, CancellationToken ct = default);
        Task UpdateAsync(T entity, CancellationToken ct = default);
        Task<List<T>?> GetAllAsync(CancellationToken ct = default);
    }
}
