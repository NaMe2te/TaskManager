using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Project : SoftDeletableEntity<long>
{
    public Project(string name, long organizationId)
    {
        Name = name;
        OrganizationId = organizationId;
    }
    
    protected Project() { }

    public string Name { get; set; }
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
}