using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class TaskCollaborator : BaseEntity<long>
{
    public long TaskId { get; set; }
    public Task Task { get; set; }

    public long CollaboratorId { get; set; }
    public User Collaborator { get; set; }
}