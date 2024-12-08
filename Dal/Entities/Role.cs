using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Role : BaseEntity<int>
{
    public Role(string name, long organizationId)
    {
        Name = name;
        OrganizationId = organizationId;
    }

    public string Name { get; set; }
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
}