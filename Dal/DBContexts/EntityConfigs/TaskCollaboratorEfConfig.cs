using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class TaskCollaboratorEfConfig : IEntityTypeConfiguration<TaskCollaborator>
{
    public void Configure(EntityTypeBuilder<TaskCollaborator> builder)
    {
        builder.HasBaseType(typeof(TrackableEntity<>));
        
        builder.HasOne(tc => tc.Task)
            .WithMany(tc => tc.TaskCollaborators)
            .HasForeignKey(tc => tc.TaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(tc => tc.Collaborator)
            .WithMany(u => u.TaskCollaborators)
            .HasForeignKey(tc => tc.CollaboratorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}