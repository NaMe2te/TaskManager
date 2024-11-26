namespace Application.Dtos;

public class TaskAssociationDto
{
    public long Id { get; set; }
    public long ParentTaskId { get; set; }
    public string? ParentTaskTitle { get; set; }
    public long AssociatedTaskId { get; set; }
    public string? AssociatedTaskTitle { get; set; }
}