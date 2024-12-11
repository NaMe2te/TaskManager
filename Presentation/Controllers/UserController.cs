using Application.Dtos;
using Application.Dtos.Task;
using Application.Services.UserServices;
using Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.BaseControllers;

namespace Presentation.Controllers;

public class UserController : BaseController<User, UserDto>
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
        : base(userService)
    {
        _userService = userService;
    }

    [HttpGet(nameof(Tasks))]
    public async Task<ActionResult<IEnumerable<TaskDto>>> Tasks([FromQuery] long userId)
    {
        return Ok(await _userService.GetTasksByUser(userId));
    }
}