using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class TaskHistoryEfConfig : IEntityTypeConfiguration<TaskHistory>
{
    public void Configure(EntityTypeBuilder<TaskHistory> builder)
    {
        builder.HasBaseType(typeof(TrackableEntity<>));
        
        builder.HasOne(t => t.User)
            .WithMany(u => u.TaskHistories)
            .HasForeignKey(t => t.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(th => th.Task)
            .WithMany(t => t.TaskHistories)
            .HasForeignKey(th => th.TaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(th => th.OldStatus)
            .WithMany()
            .HasForeignKey(th => th.OldStatusId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(th => th.NewStatus)
            .WithMany()
            .HasForeignKey(th => th.NewStatusId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}