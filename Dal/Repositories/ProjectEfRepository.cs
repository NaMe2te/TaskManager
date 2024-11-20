using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class ProjectEfRepository : BaseEfRepository<Project, long>
{
    public ProjectEfRepository(DatabaseContext context) : base(context)
    { }
}