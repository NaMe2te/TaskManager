using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class CommentEfConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Text).IsRequired().HasMaxLength(1000);
        
        builder.HasOne(x => x.Task)
            .WithMany(t => t.Comments)
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Commenter)
            .WithMany(u => u.Comments)
            .HasForeignKey(x => x.CommentedBy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}