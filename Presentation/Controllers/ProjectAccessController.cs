using Application.Dtos;
using Application.Services;
using Application.Services.BaseServices;
using Dal.Entities;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class ProjectAccessController : BaseController<ProjectAccess, ProjectAccessDto, long>
{
    public ProjectAccessController(IBaseCrudService<ProjectAccess, ProjectAccessDto, long> service) : base(service)
    {
    }
}