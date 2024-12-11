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
        
        builder.Property(ch => ch.BranchName).IsRequired();
        builder.Property(ch => ch.RepositoryOwner).IsRequired();
        builder.Property(ch => ch.RepositoryName).IsRequired();
    }
}