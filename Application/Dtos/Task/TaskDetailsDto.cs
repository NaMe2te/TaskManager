namespace Application.Dtos.Task;

public class TaskDetailsDto : TaskDto
{
    public IEnumerable<TaskCollaboratorDto> Collaborators { get; set; }
    public IEnumerable<CommentDto> Comments { get; set; }
    // TODO: CommitHistory
}