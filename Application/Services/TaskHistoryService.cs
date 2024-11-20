using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class TaskHistoryService : BaseCrudService<TaskHistory, TaskHistoryDto, int>
{
    public TaskHistoryService(IBaseRepository<TaskHistory, int> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork)
    { }
}