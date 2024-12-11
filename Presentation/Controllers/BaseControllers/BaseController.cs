using System.Net;
using Application.Services;
using Application.Services.BaseServices;
using Dal.Entities.BaseEntities;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.BaseControllers;

public abstract class BaseController<TEntity, TDto, TId> : BaseController<TEntity, TDto>
    where TEntity : BaseEntity<TId>
    where TDto : class
{
    protected readonly IBaseCrudService<TEntity, TDto, TId> _service;

    protected BaseController(IBaseCrudService<TEntity, TDto, TId> service)
        : base(service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<IEnumerable<TDto>>> Get([FromRoute] TId id)
    {
        try
        {
            var dto = await _service.GetById(id);
            return Ok(dto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TEntity, TDto> : ControllerBase
    where TDto : class
{
    protected readonly IBaseCrudService<TEntity, TDto> _service;
    
    protected virtual int PageSize => 10;

    protected BaseController(IBaseCrudService<TEntity, TDto> service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<IEnumerable<TDto>>> GetAll([FromQuery] int? pageNumber = 1)
    {
        try
        {
            PaginationParams? paginationParams = null;
        
            if (pageNumber is not null)
            {
                paginationParams = new PaginationParams(pageNumber.Value, PageSize);
            }
        
            var dtos = await _service.GetAll(paginationParams: paginationParams);
            return Ok(dtos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<TDto>> Create([FromBody] TDto dto)
    {
        try
        {
            return Ok(await _service.Add(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<TDto>> Update([FromBody] TDto dto)
    {
        try
        {
            return Ok(await _service.Update(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [HttpDelete]
    public virtual async Task<ActionResult> Remove([FromBody] TDto dto)
    {
        try
        {
            await _service.Remove(dto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}