using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class CommentEfConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasBaseType(typeof(SoftDeletableEntity<>));
        
        builder.Property(x => x.TaskId).IsRequired();
        builder.Property(x => x.CommentedBy).IsRequired();
        builder.Property(x => x.Text).HasMaxLength(1000).IsRequired();
        
        builder.HasOne(x => x.Task)
            .WithMany(t => t.Comments)
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.Commenter)
            .WithMany(u => u.Comments)
            .HasForeignKey(x => x.CommentedBy)
            .OnDelete(DeleteBehavior.NoAction);
    }
}