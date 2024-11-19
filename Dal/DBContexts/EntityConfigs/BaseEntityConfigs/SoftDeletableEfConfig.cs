using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs.BaseEntityConfigs;

public abstract class SoftDeletableEfConfig<TEntity, TId> : BaseEntityConfig<TEntity, TId>
    where TEntity : SoftDeletableEntity<TId>
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        
        builder.Property(sd => sd.IsDeleted).IsRequired();
        builder.Property(sd => sd.DateDeleted).IsRequired(false);
    }
}