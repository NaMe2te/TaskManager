using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class TaskEfConfig : IEntityTypeConfiguration<Entities.Task>
{
    public void Configure(EntityTypeBuilder<Entities.Task> builder)
    {
        builder.HasBaseType(typeof(TrackableEntity<>));
        
        builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
        builder.Property(t => t.Description).IsRequired().HasMaxLength(1000);
        builder.Property(t => t.DueDate).IsRequired(false);
        
        builder.HasOne(t => t.Creator)
            .WithMany(u => u.CreatedTasks)
            .HasForeignKey(t => t.CreatedBy)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(t => t.Assignee)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(t => t.AssignedTo)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(t => t.Status)
            .WithMany()
            .HasForeignKey(t => t.StatusId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(t => t.AssociatedTasks)
            .WithOne(ac => ac.ParentTask)
            .HasForeignKey(ta => ta.ParentTaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
            

        // не сможет удалить задачу, если у нее есть подзадачи
        builder.HasMany(ta => ta.AssociatedTasks)
            .WithOne(at => at.AssociatedTask)
            .HasForeignKey(ta => ta.AssociatedTaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(t => t.TaskCollaborators)
            .WithOne(tc => tc.Task)
            .HasForeignKey(tc => tc.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Comments)
            .WithOne(c => c.Task)
            .HasForeignKey(c => c.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.TaskHistories)
            .WithOne(th => th.Task)
            .HasForeignKey(th => th.TaskId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(t => t.CommitHistories)
            .WithOne(ch => ch.Task)
            .HasForeignKey(ch => ch.TaskId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}