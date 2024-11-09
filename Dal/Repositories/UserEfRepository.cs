using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class UserEfRepository : BaseEfRepository<User>
{
    public UserEfRepository(DatabaseContext context) : base(context) { }

    public override async Task<User> DeleteAsync(User model)
    {
        model.MarkDeleted();
        await UpdateAsync(model);
        
        return model;
    }

    public override User Delete(User model)
    {
        model.MarkDeleted();
        Update(model);
        
        return model;
    }
}