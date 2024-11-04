using Dal.Entities.BaseEntities;
using Dal.Models.Enums;

namespace Dal.Entities;

/// <summary>
/// Таблица для выдачи юзерам доступа к проектам
/// </summary>
public class ProjectAccess : SoftDeletableEntity<long>
{
    public ProjectAccess(long projectId, long userId, Access access)
    {
        ProjectId = projectId;
        UserId = userId;
        Access = access;
    }

    protected ProjectAccess() { }
    
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    
    public long UserId { get; set; }
    public User User { get; set; }
    
    public Access Access { get; set; }
}