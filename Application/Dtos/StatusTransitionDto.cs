namespace Application.Dtos;

public class StatusTransitionDto
{
    public long Id { get; set; }
    
    public long OrganizationId { get; set; }
    
    public long FromId { get; set; }
    public string? FromStatusName { get; set; }
    
    public long ToId { get; set; }
    public string? ToStatusName { get; set; }
}