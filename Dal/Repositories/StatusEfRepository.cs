using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class StatusEfRepository : SoftDeletableEfRepository<Status, int>
{
    public StatusEfRepository(DatabaseContext context) : base(context) { }
}