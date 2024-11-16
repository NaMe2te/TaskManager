namespace Application.Dtos;

public class TaskHistoryDto
{
    public int Id { get; set; }
    public long UserId { get; set; }
    public string UserName { get; set; }
    public long TaskId { get; set; }
    public int OldStatusId { get; set; }
    public string OldStatusName { get; set; }
    public int NewStatusId { get; set; }
    public string NewStatusName { get; set; }
    public DateTime DateUpdated { get; set; }
}