using Application.Dtos;
using Application.Dtos.Task;
using Application.Services;
using Application.Services.OrganizationServices;
using Application.Services.TaskServices;
using Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class OrganisationController : BaseController<Organization, OrganizationDto, long>
{
    public OrganisationController(IOrganizationService service) : base(service)
    {
    }
    
    [HttpGet(nameof(Tasks))]
    public async Task<ActionResult<IEnumerable<TaskDto>>> Tasks([FromQuery] long organization)
    {
        return Ok(await ((IOrganizationService)_service).GetAllTasks(organization));
    }
}