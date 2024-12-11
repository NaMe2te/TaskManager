using Application.Dtos;
using Application.Services;
using Application.Services.BaseServices;
using Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : BaseController<Role, RoleDto>
{
    public RoleController(IBaseCrudService<Role, RoleDto> service)
        : base(service)
    { }
}