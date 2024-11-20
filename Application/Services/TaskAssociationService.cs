using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class TaskAssociationService : BaseCrudService<TaskAssociation, TaskAssociationDto, long>
{
    public TaskAssociationService(IBaseRepository<TaskAssociation, long> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork)
    { }
}