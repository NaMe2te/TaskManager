using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class User : TrackableEntity<long>
{
    public string FullName { get; set; }
    public string Email { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    public ICollection<Task> CreatedTasks { get; set; }
    public ICollection<Task> AssignedTasks { get; set; }
    public ICollection<TaskCollaborator> TaskCollaborators { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<TaskHistory> TaskHistories { get; set; }
}