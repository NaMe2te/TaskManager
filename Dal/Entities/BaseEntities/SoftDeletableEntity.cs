namespace Dal.Entities.BaseEntities;

public class SoftDeletableEntity<TId> : TrackableEntity<TId>
{
    public DateTime? DateDeleted { get; set; }
    public bool IsDeleted { get; set; }
}