namespace Dal.Entities.BaseEntities;

/// <summary>
/// Конфигурация:
/// <para>
///     <see cref="DBContexts.EntityConfigs.BaseEntityConfigs.SoftDeletableEfConfig"/>
/// </para>
/// </summary>
public abstract class SoftDeletableEntity<TId> : BaseEntity<TId>
{
    public SoftDeletableEntity()
    {
        IsDeleted = false;
    }

    public DateTime? DateDeleted { get; set; }
    public bool IsDeleted { get; set; }

    public void MarkDeleted()
    {
        IsDeleted = true;
        DateDeleted = DateTime.Now;
    }
}