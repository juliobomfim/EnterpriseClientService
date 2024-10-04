using EnterpriseClientService.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseClientService.Infrastructure.DataContexts
{
    public class EnterpriseClientServiceContext : DbContext
    {
        public EnterpriseClientServiceContext(DbContextOptions<EnterpriseClientServiceContext> opts) : base (opts) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnterpriseClientMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
