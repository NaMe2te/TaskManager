namespace Dal.Entities.BaseEntities;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }
}