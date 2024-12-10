using System.Net;
using Application.Dtos;
using Application.Services;
using Dal.Entities;
using Dal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly RoleManager<Role> _roleManager;
    
    public RoleController(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }
    
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<IEnumerable<Role>>> GetAll([FromQuery] int? pageNumber = 1)
    {
        return await _roleManager.Roles.ToListAsync();
    }
    
    /*[HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<IEnumerable<TDto>>> Get([FromRoute] TId id)
    {
        var dto = await _service.GetById(id);
        return Ok(dto);
    }*/

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<IdentityResult>> Create([FromBody] RoleDto dto)
    {
        IdentityResult a = await _roleManager.CreateAsync(new Role(dto.Name, dto.OrganizationId));
        return Ok(a);
    }
}