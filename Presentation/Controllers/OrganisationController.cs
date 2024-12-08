using Application.Dtos;
using Application.Dtos.Task;
using Application.Services.OrganizationServices;
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

    [HttpGet(nameof(Statuses))]
    public async Task<ActionResult<IEnumerable<TaskDto>>> Statuses([FromQuery] long organization)
    {
        return Ok(await ((IOrganizationService)_service).GetAllStatuses(organization));
    }
    
    [HttpGet(nameof(StatusTransition))]
    public async Task<ActionResult<IEnumerable<TaskDto>>> StatusTransition([FromQuery] long organization)
    {
        return Ok(await ((IOrganizationService)_service).GetAllStatusTransition(organization));
    }
    
    [HttpGet(nameof(Roles))]
    public async Task<ActionResult<IEnumerable<TaskDto>>> Roles([FromQuery] long organization)
    {
        return Ok(await ((IOrganizationService)_service).GetAllRoles(organization));
    }
    
    [HttpGet(nameof(Users))]
    public async Task<ActionResult<IEnumerable<TaskDto>>> Users([FromQuery] long organization)
    {
        return Ok(await ((IOrganizationService)_service).GetAllUsers(organization));
    }
}