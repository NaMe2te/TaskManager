using Application.Dtos;
using Application.Services.BaseServices;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services.ProjectAccessServices;

public class ProjectAccessService : BaseCrudService<ProjectAccess, ProjectAccessDto, long>
{
    public ProjectAccessService(IBaseRepository<ProjectAccess, long> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : base(repository, mapper, unitOfWork)
    { }
}