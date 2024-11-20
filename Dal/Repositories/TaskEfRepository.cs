using Dal.DBContexts;
using Dal.Repositories.BaseRepositories;
using Task = Dal.Entities.Task;

namespace Dal.Repositories;

public class TaskEfRepository : BaseEfRepository<Task, long>
{
    public TaskEfRepository(DatabaseContext context) : base(context)
    { }
}