namespace Application.Dtos;

public class ProjectAccessDto
{
    public long Id { get; set; }
    
    public long ProjectId { get; set; }
    public string ProjectName { get; set; }
    
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string AccessLevel { get; set; }
}