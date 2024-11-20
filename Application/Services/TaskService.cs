using Application.Dtos;
using AutoMapper;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;
using Task = Dal.Entities.Task;

namespace Application.Services;

public class TaskService : BaseCrudService<Task, TaskDto, long>
{
    public TaskService(IBaseRepository<Task, long> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork)
    { }
}