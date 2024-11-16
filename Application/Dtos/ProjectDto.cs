namespace Application.Dtos;

public class ProjectDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long OrganizationId { get; set; }
    public string OrganizationName { get; set; } // Упрощение для отображения
    public List<TaskDto> Tasks { get; set; } = new();
}