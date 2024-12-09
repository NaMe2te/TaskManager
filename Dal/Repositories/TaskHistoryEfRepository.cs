using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class TaskHistoryEfRepository : BaseEfRepository<TaskHistory, int>
{
    public TaskHistoryEfRepository(DatabaseContext context) : base(context)
    { }
}