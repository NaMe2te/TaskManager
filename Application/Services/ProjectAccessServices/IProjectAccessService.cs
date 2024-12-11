using Application.Dtos;
using Application.Services.BaseServices;
using Dal.Entities;

namespace Application.Services.ProjectAccessServices;

public interface IProjectAccessService : IBaseCrudService<ProjectAccess, ProjectAccessDto, long>
{
    
}