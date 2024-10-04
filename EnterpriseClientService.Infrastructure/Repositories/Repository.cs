using EnterpriseClientService.Domain.Entities;
using EnterpriseClientService.Domain.Interfaces.Repositories;
using EnterpriseClientService.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseClientService.Infrastructure.Repositories
{

    public class Repository<T> : IRepository<T> where T : Entity
    {

        protected readonly EnterpriseClientServiceContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(EnterpriseClientServiceContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Delete(T entity) => _dbSet.Remove(entity);
        public async Task InsertAsync(T entity, CancellationToken ct = default) => await _dbSet.AddAsync(entity, ct);
        public async Task<T?> GetAsync(Guid id, CancellationToken ct = default) => await _dbSet.FindAsync(id, ct);
        public void Update(T entity) { entity.SetUpdateDate(); _dbSet.Update(entity); }
        public async Task<List<T>?> GetAllAsync(CancellationToken ct = default) => await _dbSet.ToListAsync(ct);
    }
}
