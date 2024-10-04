using EnterpriseClientService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseClientService.Infrastructure.Mapping
{
    public class EnterpriseClientMap : EntityMap<EnterpriseClient>
    {
        public override void ConfigureContent(EntityTypeBuilder<EnterpriseClient> builder)
        {
            builder.ToTable("EnterpriseClient");
            
            builder
                .Property(e => e.EnterpriseClientName)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(e => e.EnterpriseScale)
                .IsRequired();
        }
    }
}
