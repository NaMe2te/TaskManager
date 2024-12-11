using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    [HttpPost(nameof(Register))]
    public async Task<ActionResult<UserDto>> Register(RegisterRequestModel model)
    {
        var user = new User(model.FullName, model.Email, model.OrganizationId);

        IdentityResult createUserResult = await _userManager.CreateAsync(user, model.Password);
        
        if (!createUserResult.Succeeded)
        {
            var errors = string.Join(". ", createUserResult.Errors.Select(x => x.Description));
            return BadRequest( errors );
        }

        IdentityResult addToRoleResult = await _userManager.AddToRoleAsync(user, model.RoleName);
        if (!addToRoleResult.Succeeded)
        {
            var errors = string.Join(". ", createUserResult.Errors.Select(x => x.Description));
            return BadRequest( errors );
        } 
        
        await _signInManager.SignInAsync(user, true);

        var userDto = _mapper.Map<User, UserDto>(user, options => options.Items["Role"] = model.RoleName);
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
        
        var roles = await _userManager.GetRolesAsync(user);
        var roleName = roles.FirstOrDefault() ?? string.Empty;
        
        var userDto = _mapper.Map<User, UserDto>(user, options => options.Items["Role"] = roleName);
        return Ok(userDto);
    }

    [HttpPost(nameof(Logout))]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok("Successfully logged out.");
    }

}