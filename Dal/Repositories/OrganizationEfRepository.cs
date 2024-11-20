using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class OrganizationEfRepository : BaseEfRepository<Organization, long>
{
    public OrganizationEfRepository(DatabaseContext context) : base(context)
    { }
}