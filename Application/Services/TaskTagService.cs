using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class TaskTagService : BaseCrudService<TaskTag, TaskTagDto>
{
    protected TaskTagService(IBaseRepository<TaskTag> repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
    {
    }
}