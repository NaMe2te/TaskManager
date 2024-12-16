using Microsoft.AspNetCore.Identity;

namespace Dal.Entities;

public class Role : IdentityRole<long>
{
    public Role(string name, long organizationId)
        : base(Guid.NewGuid().ToString())
    {
        OrganizationId = organizationId;
        RoleName = name;
    }
    
    protected Role() { }
    
    public string RoleName { get; set; }
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
    
    public DateTime DateCreated { get; set; }
    public DateTime LastUpdated { get; set; }
}