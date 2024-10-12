using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs.BaseEntityConfigs;

public class BaseEntityConfig<TId> : IEntityTypeConfiguration<BaseEntity<TId>>
{
    public void Configure(EntityTypeBuilder<BaseEntity<TId>> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}