using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class TaskTag : TrackableEntity<int>
{
    public string Name { get; set; }
}