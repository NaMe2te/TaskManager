using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class TaskCollaboratorService : BaseCrudService<TaskCollaborator, TaskCollaboratorDto>
{
    protected TaskCollaboratorService(IBaseRepository<TaskCollaborator> repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
    {
    }
}