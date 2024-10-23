using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Organization : TrackableEntity<long>
{
    public Organization(string name)
    {
        Name = name;
        Projects = new List<Project>();
    }
    
    protected Organization() { }

    public string Name { get; set; }
    
    public ICollection<Project> Projects { get; set; }
}