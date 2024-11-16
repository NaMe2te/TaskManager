using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class TaskAssociationService : BaseCrudService<TaskAssociation, TaskAssociationDto>
{
    protected TaskAssociationService(IBaseRepository<TaskAssociation> repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
    {
    }
}