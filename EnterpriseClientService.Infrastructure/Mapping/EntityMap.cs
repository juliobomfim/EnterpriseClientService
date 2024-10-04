using EnterpriseClientService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseClientService.Infrastructure.Mapping
{
    public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate).IsRequired();
            ConfigureContent(builder);
        }

        public abstract void ConfigureContent(EntityTypeBuilder<TEntity> builder);
    }
}
