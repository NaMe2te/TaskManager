using System.Linq.Expressions;
using Dal.Entities.BaseEntities;
using Dal.Models;

namespace Application.Services;

public interface IBaseCrudService<TEntity, TDto, in TId> 
    where TEntity : BaseEntity<TId>
    where TDto : class
{
    Task<TDto> Add(TDto dto);
    Task<TDto> Update(TDto dto);
    Task<TDto> Remove(TDto dto);
    Task<TDto> GetById(TId id);
    Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>>? predicate = null, PaginationParams? paginationParams = null);
}