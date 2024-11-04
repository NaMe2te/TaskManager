using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class TaskAssociationEfConfig : IEntityTypeConfiguration<TaskAssociation>
{
    public void Configure(EntityTypeBuilder<TaskAssociation> builder)
    {
        builder.HasBaseType(typeof(TrackableEntity<>));
        
        builder.HasOne(ta => ta.ParentTask)
            .WithMany(t => t.AssociatedTasks)
            .HasForeignKey(ta => ta.ParentTaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(ta => ta.AssociatedTask)
            .WithMany(t => t.AssociatedTasks)
            .HasForeignKey(ta => ta.AssociatedTaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}