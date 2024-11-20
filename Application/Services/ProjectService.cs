using Application.Dtos;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services;

public class ProjectService : BaseCrudService<Project, ProjectDto, long>
{
    public ProjectService(IBaseRepository<Project, long> repository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork)
    { }
}