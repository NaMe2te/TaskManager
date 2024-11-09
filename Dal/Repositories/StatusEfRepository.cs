using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class StatusEfRepository : BaseEfRepository<Status>
{
    public StatusEfRepository(DatabaseContext context) : base(context) { }

    public override async Task<Status> DeleteAsync(Status model)
    {
        model.MarkDeleted();
        return await UpdateAsync(model);
    }

    public override Status Delete(Status model)
    {
        model.MarkDeleted();
        return Update(model);
    }
}