namespace Dal.Entities.BaseEntities;

/// <summary>
/// Конфигурация:
/// <para>
///     <see cref="DBContexts.EntityConfigs.BaseEntityConfigs.BaseEntityConfig"/>
/// </para>
/// </summary>
/// <typeparam name="TId">Тип Id сущности</typeparam>
public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }
}