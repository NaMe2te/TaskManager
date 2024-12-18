using System.Linq.Expressions;
using Dal.DBContexts;
using Dal.Entities.BaseEntities;
using Dal.Extentions;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.BaseRepositories;

public class BaseEfRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    protected readonly DatabaseContext _context;
    protected readonly string[] _allNavigationFields;

    public BaseEfRepository(DatabaseContext context)
    {
        _context = context;
        _allNavigationFields = _context.Set<TEntity>().EntityType.GetNavigations().Select(x => x.Name).ToArray();
    }

    public async Task<TEntity> AddAsync(TEntity model)
    {
        model.DateCreated = model.LastUpdated = DateTime.Now;
        var addedEntity = await _context.Set<TEntity>().AddAsync(model).ConfigureAwait(false);
    
        // Обновляем трекер изменений
        _context.ChangeTracker.DetectChanges();

        // Загружаем все навигационные свойства
        foreach (var navigationField in _allNavigationFields)
        {
            // Проверяем, является ли навигационное свойство коллекцией
            var navigation = _context.Entry(addedEntity.Entity).Metadata.FindNavigation(navigationField);
            if (navigation != null && navigation.IsCollection)
            {
                // Используем Collection для коллекций
                await _context.Entry(addedEntity.Entity).Collection(navigationField).LoadAsync().ConfigureAwait(false);
            }
            else
            {
                // Используем Reference для одиночных свойств
                await _context.Entry(addedEntity.Entity).Reference(navigationField).LoadAsync().ConfigureAwait(false);
            }
        }

        return addedEntity.Entity;
    }
    
    public TEntity Add(TEntity model)
    {
        model.DateCreated = model.LastUpdated = DateTime.Now;
        var addedEntity = _context.Set<TEntity>().Add(model).Entity;
        
        // Обновляем трекер изменений
        _context.ChangeTracker.DetectChanges();

        // Загружаем все навигационные свойства
        foreach (var navigationField in _allNavigationFields)
        {
            var navigation = _context.Entry(addedEntity).Metadata.FindNavigation(navigationField);
            if (navigation != null && navigation.IsCollection)
            {
                // Используем Collection для коллекций
                _context.Entry(addedEntity).Collection(navigationField).Load();
            }
            else
            {
                // Используем Reference для одиночных свойств
                _context.Entry(addedEntity).Reference(navigationField).Load();
            }
        }

        return addedEntity;
    }

    public async Task<TEntity> UpdateAsync(TEntity model)
    {
        var entity = _context.Set<TEntity>().Update(model).Entity;
        entity.LastUpdated = DateTime.Now;

        // Обновляем трекер изменений
        _context.ChangeTracker.DetectChanges();

        // Загружаем все навигационные свойства
        foreach (var navigationField in _allNavigationFields)
        {
            var navigation = _context.Entry(entity).Metadata.FindNavigation(navigationField);
            if (navigation != null && navigation.IsCollection)
            {
                // Используем Collection для коллекций
                await _context.Entry(entity).Collection(navigationField).LoadAsync();
            }
            else
            {
                // Используем Reference для одиночных свойств
                await _context.Entry(entity).Reference(navigationField).LoadAsync();
            }
        }

        return entity;
    }

    public TEntity Update(TEntity model)
    {
        var entity = _context.Set<TEntity>().Update(model).Entity;
        entity.LastUpdated = DateTime.Now;

        // Обновляем трекер изменений
        _context.ChangeTracker.DetectChanges();

        // Загружаем все навигационные свойства
        foreach (var navigationField in _allNavigationFields)
        {
            var navigation = _context.Entry(entity).Metadata.FindNavigation(navigationField);
            if (navigation != null && navigation.IsCollection)
            {
                // Используем Collection для коллекций
                _context.Entry(entity).Collection(navigationField).Load();
            }
            else
            {
                // Используем Reference для одиночных свойств
                _context.Entry(entity).Reference(navigationField).Load();
            }
        }

        return entity;
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
        var a = ApplyIncludes(_context.Set<TEntity>(), includes);
        return await a.FirstAsync(predicate);
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
        
        return paginationParams is not null ? 
           await query.ToPaginationListAsync(paginationParams.PageSize, paginationParams.PageNumber) : await query.ToListAsync();
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, PaginationParams? paginationParams = null, params string[] includes)
    {
        var query = ApplyIncludes(_context.Set<TEntity>(), includes);

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return paginationParams is not null ? 
            query.ToPaginationList(paginationParams.PageSize, paginationParams.PageNumber) : query.ToList();
    }

    public string[] GetNavigationFields()
    {
        return _allNavigationFields;
    }
    
    private static IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, IEnumerable<string> includes)
    {
        return includes.Aggregate(query, (current, include) => current.Include(include));
    }
}