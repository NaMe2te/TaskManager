using Application.Dtos;
using Application.Services.UserServices;
using AutoMapper;
using Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IUserService _service;
    private readonly IMapper _mapper;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, RoleManager<Role> roleManager, IUserService service)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _roleManager = roleManager;
        _service = service;
    }

    [HttpPost(nameof(Register))]
    public async Task<ActionResult<UserDto>> Register(RegisterRequestModel model)
    {
        var user = new User(model.FullName, model.Email, model.OrganizationId);

        var createUserResult = await _userManager.CreateAsync(user, model.Password);
        if (!createUserResult.Succeeded)
        {
            var errors = string.Join(". ", createUserResult.Errors.Select(x => x.Description));
            return BadRequest( errors );
        }
        
        var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
        if (role == null)
        {
            return BadRequest("Роль не найдена.");
        }

        var addToRoleResult = await _userManager.AddToRoleAsync(user, role.Name);
        if (!addToRoleResult.Succeeded)
        {
            var errors = string.Join(". ", createUserResult.Errors.Select(x => x.Description));
            return BadRequest( errors );
        } 
        
        await _signInManager.SignInAsync(user, true);

        var userDto = _mapper.Map<User, UserDto>(user, options =>
        {
            options.Items["Role"] = role.RoleName;
            options.Items["RoleId"] = role.Id;
        });
        return Ok(userDto);
    }
    
    [HttpPost(nameof(Login))]
    public async Task<ActionResult<UserDto>> Login(LoginRequestModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
    
        if (user == null)
        {
            return BadRequest("Invalid email or password.");
        }
        
        var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true, lockoutOnFailure: false);

        if (!result.Succeeded)
        {
            return BadRequest("Invalid email or password.");
        }

        await _signInManager.SignInAsync(user, true);

        var userDto = await _service.GetUserWithRole(user);
       
        return Ok(userDto);
    }

    [HttpPost(nameof(Logout))]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok("Successfully logged out.");
    }

}