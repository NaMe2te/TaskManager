using Microsoft.AspNetCore.Identity;

namespace Dal.Entities;

public class User : IdentityUser<long>
{
    public User(string fullName, string email, long organizationId)
        : base(email)
    {
        Email = email;
        FullName = fullName;
        OrganizationId = organizationId;
        CreatedTasks = new List<Task>();
        AssignedTasks = new List<Task>();
        TaskCollaborators = new List<TaskCollaborator>();
        Comments = new List<Comment>();
        TaskHistories = new List<TaskHistory>();

        IsDeleted = false;
    }
    
    protected User() { }
    
    public string FullName { get; set; }
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
    
    public DateTime? DateDeleted { get; set; }
    public bool IsDeleted { get; set; }
    
    public DateTime DateCreated { get; set; }   
    public DateTime LastUpdated { get; set; }
    
    public ICollection<Task> CreatedTasks { get; set; }
    public ICollection<Task> AssignedTasks { get; set; }
    public ICollection<TaskCollaborator> TaskCollaborators { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<TaskHistory> TaskHistories { get; set; }
}