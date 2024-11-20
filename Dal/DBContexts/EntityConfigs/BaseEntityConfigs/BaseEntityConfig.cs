using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs.BaseEntityConfigs;

public abstract class BaseEntityConfig<TEntity, TId> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<TId>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.DateCreated)
               .HasConversion(
                   v => v.ToUniversalTime(),
                   v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
               );
        builder.Property(x => x.LastUpdated)
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                );
    }
}