using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class RoleEfRepository : BaseEfRepository<Role, int>
{
    public RoleEfRepository(DatabaseContext context) : base(context)
    { }
}