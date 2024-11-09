using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories;
using Dal.Repositories.BaseRepositories;
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

        // TODO: добавить конфиг базе
        services.AddDbContext<DatabaseContext>();
        
        return services;
    }
}