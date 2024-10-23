using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Project : TrackableEntity<long>
{
    public string Name { get; set; }
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
}