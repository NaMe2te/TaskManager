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
        services.AddScoped<IBaseRepository<Comment, long>, CommentEfRepository>();
        services.AddScoped<IBaseRepository<CommitHistory, long>, CommitHistoryEfRepository>();
        services.AddScoped<IBaseRepository<Organization, long>, OrganizationEfRepository>();
        services.AddScoped<IBaseRepository<ProjectAccess, long>, ProjectAccessEfRepository>();
        services.AddScoped<IBaseRepository<Project, long>, ProjectEfRepository>();
        services.AddScoped<IBaseRepository<Status, int>, StatusEfRepository>();
        services.AddScoped<IBaseRepository<TaskAssociation, long>, TaskAssociationEfRepository>();
        services.AddScoped<IBaseRepository<TaskCollaborator, long>, TaskCollaboratorEfRepository>();
        services.AddScoped<IBaseRepository<Task, long>, TaskEfRepository>();
        services.AddScoped<IBaseRepository<TaskTag, int>, TaskTagEfRepository>();
        services.AddScoped<IBaseRepository<StatusTransition, long>, StatusTransitionRepository>();

        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DatabaseContext>(x => x.UseNpgsql(connectionString));

        services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<DatabaseContext>();

        return services;
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork<DatabaseContext>>();
        
        return services;
    }
}