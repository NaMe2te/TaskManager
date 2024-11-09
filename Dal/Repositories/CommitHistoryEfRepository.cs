using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class CommitHistoryEfRepository : BaseEfRepository<CommitHistory>
{
    public CommitHistoryEfRepository(DatabaseContext context) : base(context)
    { }
}