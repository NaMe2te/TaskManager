using Application.Dtos;
using Application.Services;
using Dal.Entities;

namespace Presentation.Controllers;

public class UserController : BaseController<User, UserDto, long>
{
    public UserController(IBaseCrudService<User, UserDto, long> service) : base(service)
    {
    }
}