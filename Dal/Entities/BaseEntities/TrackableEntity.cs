namespace Dal.Entities.BaseEntities;

public abstract class TrackableEntity<TId> : BaseEntity<TId>
{
    public DateTime DateCreated { get; set; }
    public DateTime LastUpdated { get; set; }
}