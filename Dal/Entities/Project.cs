using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Project : BaseEntity<long>
{
    public Project(string name, long organizationId)
    {
        Name = name;
        OrganizationId = organizationId;
        Tasks = new List<Task>();
    }
    
    protected Project() { }

    public string Name { get; set; }
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
    
    public ICollection<Task> Tasks { get; set; }
}