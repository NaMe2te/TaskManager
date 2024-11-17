using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class StatusController : BaseController<Status, StatusDto, int>
{
    public StatusController(IBaseCrudService<Status, StatusDto> service) : base(service)
    {
    }
}