using System.Linq.Expressions;
using Dal.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.BaseRepositories;

public class BaseEfRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DatabaseContext _context;

    public BaseEfRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity model)
    {
        var addedEntity = await _context.Set<TEntity>().AddAsync(model).ConfigureAwait(false);
        return addedEntity.Entity;
    }

    public TEntity Add(TEntity model)
    {
        return _context.Set<TEntity>().Add(model).Entity;
    }

    public Task<TEntity> UpdateAsync(TEntity model)
    {
        return Task.FromResult(_context.Set<TEntity>().Update(model).Entity);
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

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().FirstAsync(predicate);
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().First(predicate);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public TEntity? Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity> queryable = _context.Set<TEntity>();
        
        if (predicate is not null)
        {
            queryable = queryable.Where(predicate);
        }
        
        return await queryable.ToListAsync();
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity> queryable = _context.Set<TEntity>();

        if (predicate is not null)
        {
            queryable = queryable.Where(predicate);
        }

        return queryable.ToList();
    }
}