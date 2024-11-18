using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Task : TrackableEntity<int>
{
    public Task(string title, string description, long createdBy, long projectId, long? assignedTo = null, int? statusId = null, DateTime? dueDate = null)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        CreatedBy = createdBy;
        ProjectId = projectId;
        AssignedTo = assignedTo;
        StatusId = statusId;
        AssociatedTasks = new List<TaskAssociation>();
        TaskCollaborators = new List<TaskCollaborator>();
        Comments = new List<Comment>();
        TaskHistories = new List<TaskHistory>();
        CommitHistories = new List<CommitHistory>();
    }
    
    protected Task() { }

    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }

    public long CreatedBy { get; set; }
    public User Creator { get; set; }
    
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    
    public Status? Status { get; set; }
    
    public long? AssignedTo { get; set; }
    public User? Assignee { get; set; }
    
    public int? StatusId { get; set; }
    
    public ICollection<TaskAssociation> AssociatedTasks { get; set; }
    public ICollection<TaskCollaborator> TaskCollaborators { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<TaskHistory> TaskHistories { get; set; }
    public ICollection<CommitHistory> CommitHistories { get; set; }
}