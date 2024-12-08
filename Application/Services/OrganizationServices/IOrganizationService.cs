using Application.Dtos;
using Application.Dtos.Task;
using Dal.Entities;

namespace Application.Services.OrganizationServices;

public interface IOrganizationService : IBaseCrudService<Organization, OrganizationDto, long>
{
    Task<IEnumerable<TaskDto>> GetAllTasks(long organizationId);
    Task<IEnumerable<StatusDto>> GetAllStatuses(long organizationId);
    Task<IEnumerable<StatusTransitionDto>> GetAllStatusTransition(long organizationId);
}