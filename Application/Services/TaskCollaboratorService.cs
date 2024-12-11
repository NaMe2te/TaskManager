using Application.Dtos;
using Application.Services.BaseServices;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class TaskCollaboratorService : BaseCrudService<TaskCollaborator, TaskCollaboratorDto, long>
{
    public TaskCollaboratorService(IBaseRepository<TaskCollaborator, long> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork)
    { }
}