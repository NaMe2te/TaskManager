using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class OrganizationEfConfig : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.HasBaseType(typeof(TrackableEntity<>));

        builder.Property(o => o.Name).HasMaxLength(100).IsRequired();

        builder.HasMany(o => o.Projects)
            .WithOne(p => p.Organization)
            .HasForeignKey(c => c.OrganizationId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}