using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class CommentEfConfig : BaseEntityConfig<Comment, long>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);
        
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