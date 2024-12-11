using Application.Dtos;
using Application.Services.BaseServices;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;

namespace Application.Services.ProjectServices;

public class ProjectService : BaseCrudService<Project, ProjectDto, long>,
    IProjectService
{
    private readonly IBaseRepository<ProjectAccess, long> _projectAccessRepository;

    public ProjectService(IBaseRepository<Project, long> repository, IBaseRepository<ProjectAccess, long> projectAccessRepository,
        IMapper mapper, IUnitOfWork unitOfWork) 
        : base(repository, mapper, unitOfWork)
    {
        _projectAccessRepository = projectAccessRepository;
    }


    public async Task<IEnumerable<ProjectDto>> GetProjectsByUser(long userId)
    {
        var projectAccesses = await _projectAccessRepository.GetAllAsync(x => x.UserId == userId);
        var projects = projectAccesses.Select(x => x.Project);

        return _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDto>>(projects);
    }
}