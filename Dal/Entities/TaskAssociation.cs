using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class TaskAssociation : TrackableEntity<long>
{
    public TaskAssociation(long parentTaskId, long associatedTaskId)
    {
        ParentTaskId = parentTaskId;
        AssociatedTaskId = associatedTaskId;
    }

    protected TaskAssociation() { }

    public long ParentTaskId { get; set; }
    public Task ParentTask { get; set; }

    public long AssociatedTaskId { get; set; }
    public Task AssociatedTask { get; set; }
}