using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class StatusTransitionRepository : BaseEfRepository<StatusTransition, long>
{
    public StatusTransitionRepository(DatabaseContext context) : base(context)
    { }
}