using Application.AutoMapper;
using Application.Dtos;
using Application.Services;
using Dal.Entities;
using Microsoft.Extensions.DependencyInjection;
using Task = Dal.Entities.Task;

namespace Application;

public static class Bootstrapper
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        
        services.AddScoped<IBaseCrudService<Comment, CommentDto, long>, CommentService>();
        services.AddScoped<IBaseCrudService<Organization, OrganizationDto, long>, OrganizationService>();
        services.AddScoped<IBaseCrudService<ProjectAccess, ProjectAccessDto, long>, ProjectAccessService>();
        services.AddScoped<IBaseCrudService<Project, ProjectDto, long>, ProjectService>();
        services.AddScoped<IBaseCrudService<Role, RoleDto, int>, RoleService>();
        services.AddScoped<IBaseCrudService<Status, StatusDto, int>, StatusService>();
        services.AddScoped<IBaseCrudService<TaskAssociation, TaskAssociationDto, long>, TaskAssociationService>();
        services.AddScoped<IBaseCrudService<TaskCollaborator, TaskCollaboratorDto, long>, TaskCollaboratorService>();
        services.AddScoped<IBaseCrudService<TaskHistory, TaskHistoryDto, int>, TaskHistoryService>();
        services.AddScoped<IBaseCrudService<Task, TaskDto, int>, TaskService>();
        services.AddScoped<IBaseCrudService<TaskTag, TaskTagDto, int>, TaskTagService>();
        
        return services;
    }
}