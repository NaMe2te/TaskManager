namespace Application.Dtos;

public class CommentDto
{
    public long Id { get; set; }
    
    public string Text { get; set; }
    public long TaskId { get; set; }
    
    public string TaskName { get; set; }
    public long CommentedBy { get; set; }
    
    public string CommenterName { get; set; }
}