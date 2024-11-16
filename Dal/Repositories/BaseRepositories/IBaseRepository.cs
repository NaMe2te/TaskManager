using System.Linq.Expressions;

namespace Dal.Repositories.BaseRepositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity model);
    TEntity Add(TEntity model);
    
    Task<TEntity> UpdateAsync(TEntity model);
    TEntity Update(TEntity model);

    Task<TEntity> DeleteAsync(TEntity model);
    TEntity Delete(TEntity model);
    
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes);
    TEntity Get(Expression<Func<TEntity, bool>> predicate, params string[] includes);
    
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes);
    TEntity? Find(Expression<Func<TEntity, bool>> predicate, params string[] includes);
    
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includes);
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, params string[] includes);
}