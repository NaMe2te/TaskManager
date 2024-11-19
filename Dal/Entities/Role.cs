using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Role : BaseEntity<int>
{
    public Role(string name)
    {
        Name = name;
    }
    
    protected Role() { }

    public string Name { get; set; }
}