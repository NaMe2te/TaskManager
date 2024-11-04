using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Status : SoftDeletableEntity<int>
{
    public Status(string name)
    {
        Name = name;
    }
    
    protected Status() { }

    public string Name { get; set; }
}