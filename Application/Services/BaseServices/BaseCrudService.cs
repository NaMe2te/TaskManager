using System.Linq.Expressions;
using AutoMapper;
using Dal.Entities.BaseEntities;
using Dal.Models;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services.BaseServices;

public class BaseCrudService<TEntity, TDto, TId> : IBaseCrudService<TEntity, TDto, TId>
    where TEntity : BaseEntity<TId>
    where TDto : class
{
    protected readonly IBaseRepository<TEntity, TId> _repository;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    protected BaseCrudService(IBaseRepository<TEntity, TId> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public virtual async Task<TDto> Add(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity = await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> Update(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity = await _repository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> Remove(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.DeleteAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> GetById(TId id)
    {
        var entity = await _repository.GetAsync(x => x.Id!.Equals(id), _repository.GetNavigationFields());
        return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>>? predicate = null,
        PaginationParams? paginationParams = null)
    {
        var entities = await _repository.GetAllAsync(predicate, paginationParams, _repository.GetNavigationFields());
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }
}