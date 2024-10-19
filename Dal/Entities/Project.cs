using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Project : TrackableEntity<int>
{
    public string Name { get; set; }
    
    public int OrganizationId { get; set; }
    public Organization Organization { get; set; }
}