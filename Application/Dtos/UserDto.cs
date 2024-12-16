namespace Application.Dtos;

public class UserDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public long RoleId { get; set; }
    public string? RoleName { get; set; }
    public long OrganizationId { get; set; }
    public bool IsDeleted { get; set; }
}