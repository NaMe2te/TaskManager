using System.Linq.Expressions;
using Application.Dtos;
using Application.Dtos.Task;
using Application.Services.BaseServices;
using Application.Services.UserServices;
using AutoMapper;
using Dal.Entities;
using Dal.Models;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;
using Task = Dal.Entities.Task;

namespace Application.Services.OrganizationServices;

public class OrganizationService : BaseCrudService<Organization, OrganizationDto, long>,
    IOrganizationService
{
    private readonly IBaseRepository<Task, long> _taskRepository;
    private readonly IUserService _userService;

    public OrganizationService(IBaseRepository<Organization, long> repository,
        IBaseRepository<Task, long> taskRepository,
        IUserService userService,
        IMapper mapper, IUnitOfWork unitOfWork)
        : base(repository, mapper, unitOfWork)
    {
        _taskRepository = taskRepository;
        _userService = userService;
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
        return await _userService.GetUsersWithRoles(organization.Users);
    }
}