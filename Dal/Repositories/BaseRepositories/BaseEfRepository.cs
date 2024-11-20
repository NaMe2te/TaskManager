using System.Linq.Expressions;
using Dal.DBContexts;
using Dal.Entities.BaseEntities;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.BaseRepositories;

public class BaseEfRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    protected readonly DatabaseContext _context;

    public BaseEfRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity model)
    {
        model.DateCreated = model.LastUpdated = DateTime.Now;
        var addedEntity = await _context.Set<TEntity>().AddAsync(model).ConfigureAwait(false);
        return addedEntity.Entity;
    }

    public TEntity Add(TEntity model)
    {
        model.DateCreated = model.LastUpdated = DateTime.Now;
        return _context.Set<TEntity>().Add(model).Entity;
    }

    public Task<TEntity> UpdateAsync(TEntity model)
    {
        var entity = _context.Set<TEntity>().Update(model).Entity;
        entity.LastUpdated = DateTime.Now;
        return Task.FromResult(entity);
    }

    public TEntity Update(TEntity model)
    {
        return _context.Set<TEntity>().Update(model).Entity;
    }

    public virtual Task<TEntity> DeleteAsync(TEntity model)
    {
        return Task.FromResult(_context.Set<TEntity>().Remove(model).Entity);
    }

    public virtual TEntity Delete(TEntity model)
    {
        return _context.Set<TEntity>().Remove(model).Entity;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes)
    {
        return await ApplyIncludes(_context.Set<TEntity>(), includes).FirstAsync(predicate);
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate, params string[] includes)
    {
        return ApplyIncludes(_context.Set<TEntity>(), includes).First(predicate);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes)
    {
        return await ApplyIncludes(_context.Set<TEntity>(), includes).FirstOrDefaultAsync(predicate);
    }

    public TEntity? Find(Expression<Func<TEntity, bool>> predicate, params string[] includes)
    {
        return ApplyIncludes(_context.Set<TEntity>(), includes).FirstOrDefault(predicate);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, PaginationParams? paginationParams = null, params string[] includes)
    {
        var query = ApplyIncludes(_context.Set<TEntity>(), includes);
        
        if (predicate is not null)
        {
            query = query.Where(predicate);
        }
        
        if (paginationParams is not null)
        {
            query = query.Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize);
        }
        
        return await query.ToListAsync();
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, PaginationParams? paginationParams = null, params string[] includes)
    {
        var query = ApplyIncludes(_context.Set<TEntity>(), includes);

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }
        

        if (paginationParams is not null)
        {
            query = query.Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize);
        }

        return query.ToList();
    }
    
    private static IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, IEnumerable<string> includes)
    {
        return includes.Aggregate(query, (current, include) => current.Include(include));
    }
}