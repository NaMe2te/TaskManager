namespace Dal.Entities.BaseEntities;

public abstract class TrackableEntity<TId> : BaseEntity<TId>
{
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime LastUpdated { get; set; } = DateTime.Now;
}