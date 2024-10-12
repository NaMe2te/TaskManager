using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Status : TrackableEntity<int>
{
    public string Name { get; set; }
}