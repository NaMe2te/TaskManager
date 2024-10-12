using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Role : TrackableEntity<int>
{
    public string Name { get; set; }
}