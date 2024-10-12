using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class TaskAssociation : BaseEntity<int>
{
    public int ParentTaskId { get; set; }
    public Task ParentTask { get; set; }

    public int AssociatedTaskId { get; set; }
    public Task AssociatedTask { get; set; }
}