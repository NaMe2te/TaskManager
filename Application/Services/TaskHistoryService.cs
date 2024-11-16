using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class TaskHistoryService : BaseCrudService<TaskHistory, TaskHistoryDto>
{
    protected TaskHistoryService(IBaseRepository<TaskHistory> repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
    {
    }
}