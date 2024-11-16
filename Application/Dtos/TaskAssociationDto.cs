namespace Application.Dtos;

public class TaskAssociationDto
{
    public long Id { get; set; }
    public long ParentTaskId { get; set; }
    public string ParentTaskTitle { get; set; } // Упрощение для отображения
    public long AssociatedTaskId { get; set; }
    public string AssociatedTaskTitle { get; set; } // Упрощение для отображения
}