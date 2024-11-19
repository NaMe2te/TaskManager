using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class TaskCollaboratorEfConfig : BaseEntityConfig<TaskCollaborator, long>
{
    public override void Configure(EntityTypeBuilder<TaskCollaborator> builder)
    {
        base.Configure(builder);
        
        builder.HasOne(tc => tc.Task)
            .WithMany(tc => tc.TaskCollaborators)
            .HasForeignKey(tc => tc.TaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(tc => tc.Collaborator)
            .WithMany(u => u.TaskCollaborators)
            .HasForeignKey(tc => tc.CollaboratorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}