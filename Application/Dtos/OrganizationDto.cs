namespace Application.Dtos;

public class OrganizationDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<ProjectDto> Projects { get; set; } = new();
    public List<StatusDto> Statuses { get; set; } = new();
    public List<StatusTransitionDto> StatusTransitions { get; set; } = new();
}