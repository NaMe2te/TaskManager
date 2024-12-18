using System.Security.Cryptography.X509Certificates;
using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Dal.Entities.Task;

namespace Dal.DBContexts.EntityConfigs;

public class TaskEfConfig : BaseEntityConfig<Entities.Task, long>
{
    public override void Configure(EntityTypeBuilder<Entities.Task> builder)
    {
        base.Configure(builder);
        
        builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
        builder.Property(t => t.Description).IsRequired().HasMaxLength(1000);
        builder.Property(t => t.DueDate).HasConversion(
                    v => v.HasValue ? v.Value.ToUniversalTime() : DateTime.Now.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                .IsRequired(false);
        
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

        builder.HasMany(t => t.TaskCollaborators)
            .WithOne(tc => tc.Task)
            .HasForeignKey(tc => tc.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Comments)
            .WithOne(c => c.Task)
            .HasForeignKey(c => c.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.CommitHistory)
            .WithOne()
            .HasForeignKey<Task>(x => x.CommitHistoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}