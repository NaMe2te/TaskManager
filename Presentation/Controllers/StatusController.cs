using Application.Dtos;
using Application.Services;
using Application.Services.BaseServices;
using Dal.Entities;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class StatusController : BaseController<Status, StatusDto, int>
{
    public StatusController(IBaseCrudService<Status, StatusDto, int> service) : base(service)
    {
    }
}