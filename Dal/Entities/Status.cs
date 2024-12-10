using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Status : SoftDeletableEntity<int>
{
    public Status(string name, string color, long organizationId)
    {
        Name = name;
        Color = color;
        OrganizationId = organizationId;
    }
    
    protected Status() { }

    public string Color { get; set; }
    public string Name { get; set; }
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
}