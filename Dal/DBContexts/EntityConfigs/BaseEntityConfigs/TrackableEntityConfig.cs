﻿using Dal.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.DBContexts.EntityConfigs.BaseEntityConfigs;

/// <summary>
/// Конфигурация:
/// <para>
///     <see cref="DBContexts.EntityConfigs.BaseEntityConfigs.TrackableEntityConfig"/>
/// </para>
/// </summary>
public class TrackableEntityConfig<TId> : IEntityTypeConfiguration<TrackableEntity<TId>>
{
    public void Configure(EntityTypeBuilder<TrackableEntity<TId>> builder)
    {
        builder.HasBaseType(typeof(BaseEntity<>));
        
        builder.Property(x => x.DateCreated).ValueGeneratedOnAdd();
        builder.Property(x => x.LastUpdated).ValueGeneratedOnAddOrUpdate();
    }
}