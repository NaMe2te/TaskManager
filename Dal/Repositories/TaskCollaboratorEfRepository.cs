using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class TaskCollaboratorEfRepository : BaseEfRepository<TaskCollaborator>
{
    public TaskCollaboratorEfRepository(DatabaseContext context) : base(context)
    { }
}