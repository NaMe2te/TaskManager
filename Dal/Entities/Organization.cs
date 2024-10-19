using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Organization : TrackableEntity<int>
{
    public string Name { get; set; }
    
    public ICollection<Project> Projects { get; set; }
}