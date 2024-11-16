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
    protected readonly IBaseCrudService<TEntity, TDto> _service;

    protected BaseController(IBaseCrudService<TEntity, TDto> service)
    {
        _service = service;
    }

    [HttpGet(nameof(GetAll))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<TDto>>> GetAll([FromBody] PaginationParams? paginationParams = null)
    {
        var dtos = await _service.GetAll(paginationParams: paginationParams);
        return Ok(dtos);
    }

    [HttpPost(nameof(Create))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<TDto>> Create([FromBody] TDto dto)
    {
        return Ok(await _service.Add(dto));
    }

    [HttpPut(nameof(Update))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<TDto>> Update([FromBody] TDto dto)
    {
        return Ok(await _service.Update(dto));
    }
    
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> Remove([FromBody] TDto dto)
    {
        await _service.Remove(dto);
        return Ok();
    }
}