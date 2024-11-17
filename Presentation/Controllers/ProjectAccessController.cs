using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class ProjectAccessController : BaseController<ProjectAccess, ProjectAccessDto, long>
{
    public ProjectAccessController(IBaseCrudService<ProjectAccess, ProjectAccessDto, long> service) : base(service)
    {
    }
}