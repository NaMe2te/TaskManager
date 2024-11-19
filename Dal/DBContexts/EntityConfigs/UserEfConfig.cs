using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class UserEfConfig : BaseEntityConfig<User, long>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
        builder.HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(u => u.CreatedTasks)
            .WithOne(t => t.Creator)
            .HasForeignKey(t => t.CreatedBy)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(u => u.AssignedTasks)
            .WithOne(t => t.Assignee)
            .HasForeignKey(t => t.AssignedTo)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(u => u.TaskCollaborators)
            .WithOne(tc => tc.Collaborator)
            .HasForeignKey(tc => tc.CollaboratorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(u => u.Comments)
            .WithOne(c => c.Commenter)
            .HasForeignKey(c => c.CommentedBy)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(u => u.TaskHistories)
            .WithOne(th => th.User)
            .HasForeignKey(th => th.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}