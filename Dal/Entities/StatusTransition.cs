using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class StatusTransition : BaseEntity<long>
{
    public StatusTransition(int fromId, int toId)
    {
        FromId = fromId;
        ToId = toId;
    }

    public int FromId { get; set; }
    public Status From { get; set; }
    
    public int ToId { get; set; }
    public Status To { get; set; }
}