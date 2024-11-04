using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class TaskTag : TrackableEntity<int>
{
    public TaskTag(string name)
    {
        Name = name;
    }

    protected TaskTag() { }

    public string Name { get; set; }
}