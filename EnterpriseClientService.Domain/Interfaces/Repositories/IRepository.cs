using EnterpriseClientService.Domain.Entities;

namespace EnterpriseClientService.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task InsertAsync(T entity, CancellationToken ct = default);
        void Delete(T entity);
        Task<T?> GetAsync(Guid id, CancellationToken ct = default);
        Task<List<T>?> GetAllAsync(CancellationToken ct = default);
        void Update(T entity);
    }
}
