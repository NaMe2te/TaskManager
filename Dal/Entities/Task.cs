using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Task : TrackableEntity<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public int StatusId { get; set; }

    public int CreatedBy { get; set; }
    public User Creator { get; set; }
    
    public int? AssignedTo { get; set; }
    public User? Assignee { get; set; }
    
    public Status Status { get; set; }

    public ICollection<TaskAssociation> ParentTasks { get; set; }
    public ICollection<TaskAssociation> AssociatedTasks { get; set; }
    public ICollection<TaskCollaborator> TaskCollaborators { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<TaskHistory> TaskHistories { get; set; }
    public ICollection<CommitHistory> CommitHistories { get; set; }
}