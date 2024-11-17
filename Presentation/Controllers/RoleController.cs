using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class RoleController : BaseController<Role, RoleDto, int>
{
    public RoleController(IBaseCrudService<Role, RoleDto> service) : base(service)
    {
    }
}