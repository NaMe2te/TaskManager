using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class CommitHistoryEfConfig : IEntityTypeConfiguration<CommitHistory>
{
    public void Configure(EntityTypeBuilder<CommitHistory> builder)
    {
        builder.HasBaseType(typeof(BaseEntity<>));

        builder.Property(ch => ch.CommitHash).IsRequired();
        builder.Property(ch => ch.CommitDate).ValueGeneratedOnAdd().IsRequired();
        builder.Property(ch => ch.CommitNumber).IsRequired();
        builder.Property(ch => ch.AuthorId).IsRequired();
        builder.Property(ch => ch.TaskId).IsRequired();

        builder.HasOne(ch => ch.Author)
            .WithMany()
            .HasForeignKey(ch => ch.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}