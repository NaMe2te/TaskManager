namespace Dal.Entities.BaseEntities;

/// <summary>
/// Конфигурация:
/// <para>
///     <see cref="DBContexts.EntityConfigs.BaseEntityConfigs.SoftDeletableEfConfig"/>
/// </para>
/// </summary>
public abstract class SoftDeletableEntity<TId> : TrackableEntity<TId>
{
    public SoftDeletableEntity()
    {
        IsDeleted = false;
    }

    public DateTime? DateDeleted { get; set; }
    public bool IsDeleted { get; set; }
}