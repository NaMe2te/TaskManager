using System.Security.Cryptography.X509Certificates;
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
        
        services.AddScoped<IBaseCrudService<Comment, CommentDto>, CommentService>();
        services.AddScoped<IBaseCrudService<Organization, OrganizationDto>, OrganizationService>();
        services.AddScoped<IBaseCrudService<ProjectAccess, ProjectAccessDto>, ProjectAccessService>();
        services.AddScoped<IBaseCrudService<Project, ProjectDto>, ProjectService>();
        services.AddScoped<IBaseCrudService<Role, RoleDto>, RoleService>();
        services.AddScoped<IBaseCrudService<Status, StatusDto>, StatusService>();
        services.AddScoped<IBaseCrudService<TaskAssociation, TaskAssociationDto>, TaskAssociationService>();
        services.AddScoped<IBaseCrudService<TaskCollaborator, TaskCollaboratorDto>, TaskCollaboratorService>();
        services.AddScoped<IBaseCrudService<TaskHistory, TaskHistoryDto>, TaskHistoryService>();
        services.AddScoped<IBaseCrudService<Task, TaskDto>, TaskService>();
        services.AddScoped<IBaseCrudService<TaskTag, TaskTagDto>, TaskTagService>();
        
        return services;
    }
}