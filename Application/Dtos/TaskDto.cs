namespace Application.Dtos;

public class TaskDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public long CreatedBy { get; set; }
    public string CreatorName { get; set; } = string.Empty;
    public long ProjectId { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public long? AssignedTo { get; set; }
    public string? AssigneeName { get; set; }
    public int? StatusId { get; set; }
    public string? StatusName { get; set; }
}