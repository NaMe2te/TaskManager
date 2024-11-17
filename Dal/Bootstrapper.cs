using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories;
using Dal.Repositories.BaseRepositories;
using Dal.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task = Dal.Entities.Task;

namespace Dal;

public static class Bootstrapper
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<Comment>, CommentEfRepository>();
        services.AddScoped<IBaseRepository<CommitHistory>, CommitHistoryEfRepository>();
        services.AddScoped<IBaseRepository<Organization>, OrganizationEfRepository>();
        services.AddScoped<IBaseRepository<ProjectAccess>, ProjectAccessEfRepository>();
        services.AddScoped<IBaseRepository<Project>, ProjectEfRepository>();
        services.AddScoped<IBaseRepository<Role>, RoleEfRepository>();
        services.AddScoped<IBaseRepository<Status>, StatusEfRepository>();
        services.AddScoped<IBaseRepository<TaskAssociation>, TaskAssociationEfRepository>();
        services.AddScoped<IBaseRepository<TaskCollaborator>, TaskCollaboratorEfRepository>();
        services.AddScoped<IBaseRepository<Task>, TaskEfRepository>();
        services.AddScoped<IBaseRepository<TaskHistory>, TaskHistoryEfRepository>();
        services.AddScoped<IBaseRepository<TaskTag>, TaskTagEfRepository>();
        services.AddScoped<IBaseRepository<User>, UserEfRepository>();

        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DatabaseContext>(x => x.UseNpgsql(connectionString));

        return services;
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork<DatabaseContext>>();
        
        return services;
    }
}