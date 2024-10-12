using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class TaskCollaborator : BaseEntity<int>
{
    public int TaskId { get; set; }
    public Task Task { get; set; }

    public int CollaboratorId { get; set; }
    public User Collaborator { get; set; }
}