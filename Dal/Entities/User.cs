using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class User : SoftDeletableEntity<long>
{
    public User(string fullName, string email, int roleId, long organizationId)
    {
        FullName = fullName;
        Email = email;
        RoleId = roleId;
        OrganizationId = organizationId;
        CreatedTasks = new List<Task>();
        AssignedTasks = new List<Task>();
        TaskCollaborators = new List<TaskCollaborator>();
        Comments = new List<Comment>();
        TaskHistories = new List<TaskHistory>();
    }
    
    public string FullName { get; set; }
    public string Email { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
    
    public ICollection<Task> CreatedTasks { get; set; }
    public ICollection<Task> AssignedTasks { get; set; }
    public ICollection<TaskCollaborator> TaskCollaborators { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<TaskHistory> TaskHistories { get; set; }
}