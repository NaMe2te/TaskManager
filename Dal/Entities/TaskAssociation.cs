using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class TaskAssociation : BaseEntity<long>
{
    public long ParentTaskId { get; set; }
    public Task ParentTask { get; set; }

    public long AssociatedTaskId { get; set; }
    public Task AssociatedTask { get; set; }
}