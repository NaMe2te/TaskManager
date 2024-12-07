using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class StatusTransitionController : BaseController<StatusTransition, StatusTransitionDto, long>
{
    public StatusTransitionController(IBaseCrudService<StatusTransition, StatusTransitionDto, long> service) 
        : base(service)
    { }
}