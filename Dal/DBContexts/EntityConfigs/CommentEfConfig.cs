using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class CommentEfConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasBaseType(typeof(TrackableEntity<>));
        
        builder.Property(x => x.Text).HasMaxLength(1000).IsRequired();
        
        builder.HasOne(x => x.Task)
            .WithMany(t => t.Comments)
            .HasForeignKey(x => x.TaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Commenter)
            .WithMany(u => u.Comments)
            .HasForeignKey(x => x.CommentedBy)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}