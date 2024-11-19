using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class RoleEfConfig : BaseEntityConfig<Role, int>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);
        
        builder.Property(r => r.Name).HasMaxLength(50).IsRequired();
    }
}