using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class ProjectAccessEfRepository : BaseEfRepository<ProjectAccess, long>
{
    public ProjectAccessEfRepository(DatabaseContext context) : base(context)
    { }
}