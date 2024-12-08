using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class StatusTransition : BaseEntity<long>
{
    public StatusTransition(long organizationId, int fromId, int toId)
    {
        OrganizationId = organizationId;
        FromId = fromId;
        ToId = toId;
    }
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }

    public int FromId { get; set; }
    public Status From { get; set; }
    
    public int ToId { get; set; }
    public Status To { get; set; }
}