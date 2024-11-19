using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class ProjectAccessEfConfig : BaseEntityConfig<ProjectAccess, long>
{
    public override void Configure(EntityTypeBuilder<ProjectAccess> builder)
    {
        base.Configure(builder);
        
        builder.Property(pa => pa.Access).IsRequired();
        
        builder.HasIndex(pa => new { pa.ProjectId, pa.UserId }).IsUnique();
        
        builder.HasOne(pa => pa.Project)
            .WithMany()
            .HasForeignKey(pa => pa.ProjectId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(pa => pa.User)
            .WithMany()
            .HasForeignKey(pa => pa.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}