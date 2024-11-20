using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class StatusService : BaseCrudService<Status, StatusDto, int>
{
    public StatusService(IBaseRepository<Status, int> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork)
    { }
}