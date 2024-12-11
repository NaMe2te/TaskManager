using Application.Dtos;
using Application.Services.BaseServices;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services.StatusTransitionService;

public class StatusTransitionService : BaseCrudService<StatusTransition, StatusTransitionDto, long>
{
    public StatusTransitionService(IBaseRepository<StatusTransition, long> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork) { }
}