using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class StatusTransitionEfConfig : BaseEntityConfig<StatusTransition, long>
{
    public override void Configure(EntityTypeBuilder<StatusTransition> builder)
    {
        base.Configure(builder);
        
        builder.HasOne(x => x.To)
            .WithMany()
            .HasForeignKey(x => x.ToId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.From)
            .WithMany()
            .HasForeignKey(x => x.FromId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.Organization)
            .WithMany(x => x.StatusTransitions)
            .HasForeignKey(x => x.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}