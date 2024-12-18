using Application.Dtos;
using Application.Services.BaseServices;
using Application.Services.StatusTransitionService;
using Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class StatusTransitionController : BaseController<StatusTransition, StatusTransitionDto, long>
{
    public StatusTransitionController(IStatusTransitionService service) : base(service)
    {
    }

    [HttpGet(nameof(GetStatusTransitionsToFrom))]
    public async Task<ActionResult<IEnumerable<StatusTransitionDto>>> GetStatusTransitionsToFrom([FromQuery] int statusId)
    {
        return Ok(await ((IStatusTransitionService) _service).GetStatusTransitionsToFrom(statusId));
    }
}