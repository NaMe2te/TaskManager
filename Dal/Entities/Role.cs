using Microsoft.AspNetCore.Identity;

namespace Dal.Entities;

public class Role : IdentityRole<long>
{
    public Role(string name, long organizationId)
        : base(name)
    {
        OrganizationId = organizationId;
    }
    
    
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
    
    public DateTime DateCreated { get; set; }
    public DateTime LastUpdated { get; set; }
}