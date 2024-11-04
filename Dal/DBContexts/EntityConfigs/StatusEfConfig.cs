using Dal.Entities;
using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs;

public class StatusEfConfig : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasBaseType(typeof(SoftDeletableEntity<>));
        
        builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
    }
}