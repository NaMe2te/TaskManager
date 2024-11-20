using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class TaskTagEfRepository : BaseEfRepository<TaskTag, int>
{
    public TaskTagEfRepository(DatabaseContext context) : base(context)
    { }
}