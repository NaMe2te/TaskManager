using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class TaskAssociationEfConfig : BaseEntityConfig<TaskAssociation, long>
{
    public override void Configure(EntityTypeBuilder<TaskAssociation> builder)
    {
        base.Configure(builder);
        
        builder.HasOne(ta => ta.ParentTask)
            .WithMany(t => t.AssociatedTasks)
            .HasForeignKey(ta => ta.ParentTaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(ta => ta.AssociatedTask)
            .WithMany()
            .HasForeignKey(ta => ta.AssociatedTaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}