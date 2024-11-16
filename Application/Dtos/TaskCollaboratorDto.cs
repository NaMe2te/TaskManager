namespace Application.Dtos;

public class TaskCollaboratorDto
{
    public long Id { get; set; }
    public long TaskId { get; set; }
    public long CollaboratorId { get; set; }
    public string CollaboratorName { get; set; }
}