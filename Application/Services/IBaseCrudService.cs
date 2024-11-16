using System.Linq.Expressions;
using Dal.Models;

namespace Application.Services;

public interface IBaseCrudService<TEntity, TDto> 
    where TEntity : class
    where TDto : class
{
    Task<TDto> Add(TDto dto);
    Task<TDto> Update(TDto dto);
    Task<TDto> Remove(TDto dto);
    Task<TDto> Get(Expression<Func<TEntity, bool>> predicate, params string[] includes);
    Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>>? predicate = null, PaginationParams? paginationParams = null, params string[] includes);
}