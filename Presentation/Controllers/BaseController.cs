using System.Net;
using Application.Services;
using Dal.Entities.BaseEntities;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TEntity, TDto, TId> : ControllerBase
    where TEntity : BaseEntity<TId>
    where TDto : class
{
    protected readonly IBaseCrudService<TEntity, TDto, TId> _service;
    
    protected virtual int PageSize => 10;

    protected BaseController(IBaseCrudService<TEntity, TDto, TId> service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<IEnumerable<TDto>>> GetAll([FromQuery] int? pageNumber = 1)
    {
        PaginationParams? paginationParams = null;
        
        if (pageNumber is not null)
        {
            paginationParams = new PaginationParams(pageNumber.Value, PageSize);
        }
        
        var dtos = await _service.GetAll(paginationParams: paginationParams);
        return Ok(dtos);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<IEnumerable<TDto>>> Get([FromRoute] TId id)
    {
        var dto = await _service.GetById(id);
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<TDto>> Create([FromBody] TDto dto)
    {
        return Ok(await _service.Add(dto));
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<ActionResult<TDto>> Update([FromBody] TDto dto)
    {
        return Ok(await _service.Update(dto));
    }
    
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [HttpDelete]
    public virtual async Task<ActionResult> Remove([FromBody] TDto dto)
    {
        await _service.Remove(dto);
        return Ok();
    }
}