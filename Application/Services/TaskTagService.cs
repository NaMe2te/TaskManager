using Application.Dtos;
using Application.Services.BaseServices;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class TaskTagService : BaseCrudService<TaskTag, TaskTagDto, int>
{
    public TaskTagService(IBaseRepository<TaskTag, int> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork)
    { }
}