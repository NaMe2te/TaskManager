using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class TaskHistory : TrackableEntity<int>
{
    public int TaskId { get; set; }
    public Task Task { get; set; }
    
    public int OldStatusId { get; set; }
    public Status OldStatus { get; set; }
    
    public int NewStatusId { get; set; }
    public Status NewStatus { get; set; }
}