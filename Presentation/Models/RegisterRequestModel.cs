namespace Presentation.Models;

public class RegisterRequestModel
{
    public string FullName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public long OrganizationId { get; set; }
    public long RoleId { get; set; }
}