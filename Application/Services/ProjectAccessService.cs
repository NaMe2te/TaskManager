using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class ProjectAccessService : BaseCrudService<ProjectAccess, ProjectAccessDto, long>
{
    public ProjectAccessService(IBaseRepository<ProjectAccess> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : base(repository, mapper, unitOfWork)
    { }
}