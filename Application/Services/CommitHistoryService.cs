using Application.Dtos;
using Application.Services.BaseServices;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class CommitHistoryService : BaseCrudService<CommitHistory, CommitHistoryDto, long>
{
    public CommitHistoryService(IBaseRepository<CommitHistory, long> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork)
    { }
}