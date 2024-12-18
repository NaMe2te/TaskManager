using Application.Dtos;
using Application.Services.BaseServices;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services.StatusTransitionService;

public class StatusTransitionService : BaseCrudService<StatusTransition, StatusTransitionDto, long>, IStatusTransitionService
{
    public StatusTransitionService(IBaseRepository<StatusTransition, long> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork) { }

    public async Task<IEnumerable<StatusTransitionDto>> GetStatusTransitionsToFrom(int statusTo)
    {
        var statuses = await _repository.GetAllAsync();
        var result = statuses.Where(x => x.ToId == statusTo)
            .Select(x => x.FromId);
        
        return result
            .Select(fromStatusId => new StatusTransitionDto
            {
                FromId = fromStatusId, ToId = statusTo
            });
    }
}