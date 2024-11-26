namespace Application.Dtos;

public class UserDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public bool IsDeleted { get; set; }
}