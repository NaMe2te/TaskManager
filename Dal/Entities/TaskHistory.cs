using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class TaskHistory : TrackableEntity<int>
{
    public TaskHistory(long userId, long taskId, int statusId)
    {
        UserId = userId;
        TaskId = taskId;
        OldStatusId = statusId;
        NewStatusId = statusId;
    }

    protected TaskHistory() { }
    
    public long UserId { get; set; }
    public User User { get; set; }
    
    public long TaskId { get; set; }
    public Task Task { get; set; }
    
    public int OldStatusId { get; set; }
    public Status OldStatus { get; set; }
    
    public int NewStatusId { get; set; }
    public Status NewStatus { get; set; }
}