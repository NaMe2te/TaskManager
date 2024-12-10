using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class RoleEfConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
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
        
        builder.Property(r => r.Name).HasMaxLength(50).IsRequired();
    }
}