using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class OrganisationController : BaseController<Organization, OrganizationDto, long>
{
    public OrganisationController(IBaseCrudService<Organization, OrganizationDto, long> service) : base(service)
    {
    }
}