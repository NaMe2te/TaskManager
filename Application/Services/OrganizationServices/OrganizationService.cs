using Application.Dtos;
using Application.Dtos.Task;
using Application.Services.BaseServices;
using AutoMapper;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;
using Task = Dal.Entities.Task;

namespace Application.Services.OrganizationServices;

public class OrganizationService : BaseCrudService<Organization, OrganizationDto, long>,
    IOrganizationService
{
    private readonly IBaseRepository<Task, long> _taskRepository;

    public OrganizationService(IBaseRepository<Organization, long> repository,
        IBaseRepository<Task, long> taskRepository, IMapper mapper, IUnitOfWork unitOfWork)
        : base(repository, mapper, unitOfWork)
    {
        _taskRepository = taskRepository;
    }


    public async Task<IEnumerable<TaskDto>> GetAllTasks(long organizationId)
    {
         var organization = await _repository.GetAsync(x => x.Id == organizationId, _repository.GetNavigationFields());

         var tasksByOrganization = new List<Task>();
         
         foreach (var project in organization.Projects)
         {
             var tasks = await _taskRepository.GetAllAsync(task => task.ProjectId == project.Id);
             tasksByOrganization.AddRange(tasks);
         }

         return _mapper.Map<IEnumerable<Task>, IEnumerable<TaskDto>>(tasksByOrganization);
    }

    public async Task<IEnumerable<StatusDto>> GetAllStatuses(long organizationId)
    {
        var organization = await _repository.GetAsync(x => x.Id == organizationId, "Statuses");
        return _mapper.Map<IEnumerable<Status>, IEnumerable<StatusDto>>(organization.Statuses);
    }

    public async Task<IEnumerable<StatusTransitionDto>> GetAllStatusTransition(long organizationId)
    {
        var organization = await _repository.GetAsync(
            x => x.Id == organizationId,
            "StatusTransitions.From",
            "StatusTransitions.To"
        );

        return _mapper.Map<IEnumerable<StatusTransition>, IEnumerable<StatusTransitionDto>>(organization.StatusTransitions);
    }

    public async Task<IEnumerable<RoleDto>> GetAllRoles(long organizationId)
    {
        var organization = await _repository.GetAsync(x => x.Id == organizationId, "Roles");
        return _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>>(organization.Roles);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsers(long organizationId)
    {
        var organization = await _repository.GetAsync(x => x.Id == organizationId, "Users");
        return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(organization.Users);
    }
}