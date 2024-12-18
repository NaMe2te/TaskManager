namespace Application.Dtos.Task;

public class TaskDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public long CreatedBy { get; set; }
    public string? CreatorName { get; set; }
    public long ProjectId { get; set; }
    public long CommitHistoryId { get; set; }
    public string? ProjectName { get; set; }
    public long? AssignedTo { get; set; }
    public string? AssigneeName { get; set; }
    
    public int? StatusId { get; set; }
    public StatusDto? Status { get; set; }
}