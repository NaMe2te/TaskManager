namespace Application.Dtos;

public class StatusDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long OrganizationId { get; set; }
    public bool IsDeleted { get; set; }
}