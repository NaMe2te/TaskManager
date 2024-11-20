using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class TaskAssociationEfRepository : BaseEfRepository<TaskAssociation, long>
{
    public TaskAssociationEfRepository(DatabaseContext context) : base(context)
    { }
}