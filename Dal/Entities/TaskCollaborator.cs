using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class TaskCollaborator : BaseEntity<long>
{
    public TaskCollaborator(long taskId, long collaboratorId)
    {
        TaskId = taskId;
        CollaboratorId = collaboratorId;
    }

    protected TaskCollaborator() { }

    public long TaskId { get; set; }
    public Task Task { get; set; }

    public long CollaboratorId { get; set; }
    public User Collaborator { get; set; }
}