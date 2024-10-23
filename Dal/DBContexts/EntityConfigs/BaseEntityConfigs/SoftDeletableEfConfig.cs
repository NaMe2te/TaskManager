using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs.BaseEntityConfigs;

public class SoftDeletableEfConfig<Id> : IEntityTypeConfiguration<SoftDeletableEntity<Id>>
{
    public void Configure(EntityTypeBuilder<SoftDeletableEntity<Id>> builder)
    {
        builder.HasBaseType(typeof(TrackableEntity<>));
        
        builder.Property(sd => sd.IsDeleted).IsRequired();
        builder.Property(sd => sd.DateDeleted).IsRequired(false);
    }
}