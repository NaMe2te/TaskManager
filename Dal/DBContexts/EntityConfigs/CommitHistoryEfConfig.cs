using Dal.DBContexts.EntityConfigs.BaseEntityConfigs;
using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class CommitHistoryEfConfig : BaseEntityConfig<CommitHistory, long>
{
    public override void Configure(EntityTypeBuilder<CommitHistory> builder)
    {
        base.Configure(builder);

        builder.Property(ch => ch.CommitHash).IsRequired();
        builder.Property(ch => ch.CommitDate).HasConversion(
            v => v.ToUniversalTime(), // Convert to UTC before saving
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc) // Convert back to UTC when reading
        );
        builder.Property(ch => ch.CommitNumber).IsRequired();
        builder.Property(ch => ch.AuthorId).IsRequired();
        builder.Property(ch => ch.TaskId).IsRequired();

        builder.HasOne(ch => ch.Author)
            .WithMany()
            .HasForeignKey(ch => ch.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}