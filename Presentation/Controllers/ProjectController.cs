using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class ProjectController : BaseController<Project, ProjectDto, long>
{
    public ProjectController(IBaseCrudService<Project, ProjectDto, long> service) : base(service)
    {
    }
}