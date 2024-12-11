using System.Linq.Expressions;
using Dal.Entities.BaseEntities;
using Dal.Models;

namespace Application.Services.BaseServices;

public interface IBaseCrudService<TEntity, TDto, in TId> : IBaseCrudService<TEntity, TDto>
    where TEntity : BaseEntity<TId>
    where TDto : class
{
    Task<TDto> GetById(TId id);
}

public interface IBaseCrudService<TEntity, TDto> 
{
    Task<TDto> Add(TDto dto);
    Task<TDto> Update(TDto dto);
    Task<TDto> Remove(TDto dto);
    Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>>? predicate = null, PaginationParams? paginationParams = null);
}