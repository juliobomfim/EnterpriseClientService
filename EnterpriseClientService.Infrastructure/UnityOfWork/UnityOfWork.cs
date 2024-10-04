using EnterpriseClientService.Domain.Interfaces.UnityOfWork;
using EnterpriseClientService.Infrastructure.DataContexts;

namespace EnterpriseClientService.Infrastructure.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly EnterpriseClientServiceContext _context;
        public UnityOfWork(EnterpriseClientServiceContext context) { _context = context; }
        public async Task CommitAsync(CancellationToken ct = default) => await _context.SaveChangesAsync(ct);
    }
}
