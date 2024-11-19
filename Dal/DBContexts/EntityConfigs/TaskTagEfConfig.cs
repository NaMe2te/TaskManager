using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class TaskTagEfConfig : BaseEntityConfig<TaskTag, int>
{
    public override void Configure(EntityTypeBuilder<TaskTag> builder)
    {
        base.Configure(builder);
        
        builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
    }
}