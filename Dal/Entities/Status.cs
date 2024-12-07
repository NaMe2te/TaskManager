using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Status : SoftDeletableEntity<int>
{
    public Status(string name, long organizationId)
    {
        Name = name;
        OrganizationId = organizationId;
    }
    
    protected Status() { }

    public string Name { get; set; }
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
}