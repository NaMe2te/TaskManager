using Application.Dtos;
using Application.Services;
using Application.Services.BaseServices;
using Dal.Entities;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class StatusTransitionController : BaseController<StatusTransition, StatusTransitionDto, long>
{
    public StatusTransitionController(IBaseCrudService<StatusTransition, StatusTransitionDto, long> service) 
        : base(service)
    { }
}