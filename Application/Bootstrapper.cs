using Application.AutoMapper;
using Application.Dtos;
using Application.Services;
using Application.Services.BaseServices;
using Application.Services.OrganizationServices;
using Application.Services.ProjectAccessServices;
using Application.Services.ProjectServices;
using Application.Services.StatusTransitionService;
using Application.Services.TaskServices;
using Application.Services.UserServices;
using Dal.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Bootstrapper
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        
        services.AddScoped<IBaseCrudService<Comment, CommentDto, long>, CommentService>();
        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<IBaseCrudService<ProjectAccess, ProjectAccessDto, long>, ProjectAccessService>();
        services.AddScoped<IBaseCrudService<Project, ProjectDto, long>, ProjectService>();
        services.AddScoped<IBaseCrudService<Status, StatusDto, int>, StatusService>();
        services.AddScoped<IBaseCrudService<TaskAssociation, TaskAssociationDto, long>, TaskAssociationService>();
        services.AddScoped<IBaseCrudService<TaskCollaborator, TaskCollaboratorDto, long>, TaskCollaboratorService>();
        services.AddScoped<IBaseCrudService<StatusTransition, StatusTransitionDto, long>, StatusTransitionService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IBaseCrudService<TaskTag, TaskTagDto, int>, TaskTagService>();
        services.AddScoped<IBaseCrudService<CommitHistory, CommitHistoryDto, long>, CommitHistoryService>();
        services.AddScoped<IBaseCrudService<Role, RoleDto>, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProjectService, ProjectService>();
        
        return services;
    }
}