using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class UserEfConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.DateCreated)
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );
        builder.Property(x => x.LastUpdated)
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );
        
        builder.Property(sd => sd.IsDeleted).IsRequired();
        builder.Property(sd => sd.DateDeleted).IsRequired(false);
        
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
        
        builder.HasOne(u => u.Organization)
            .WithMany(th => th.Users)
            .HasForeignKey(th => th.OrganizationId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}