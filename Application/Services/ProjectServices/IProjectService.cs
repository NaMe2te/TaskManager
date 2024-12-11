using Application.Dtos;
using Application.Services.BaseServices;
using Dal.Entities;

namespace Application.Services.ProjectServices;

public interface IProjectService : IBaseCrudService<Project, ProjectDto, long>
{
    Task<IEnumerable<ProjectDto>> GetProjectsByUser(long userId);
}