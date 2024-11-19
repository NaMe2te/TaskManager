using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class StatusEfConfig : SoftDeletableEfConfig<Status, int>
{
    public override void Configure(EntityTypeBuilder<Status> builder)
    {
        base.Configure(builder);
        
        builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
    }
}