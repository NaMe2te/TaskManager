using Application.Dtos;
using Application.Services.ProjectServices;
using Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class ProjectController : BaseController<Project, ProjectDto, long>
{
    public ProjectController(IProjectService service) : base(service)
    { }

    [HttpGet(nameof(GetProjectsByUser))]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjectsByUser([FromQuery] long userId)
    {
        return Ok(await ((IProjectService)_service).GetProjectsByUser(userId));
    }
}