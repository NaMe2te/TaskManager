using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class UserEfRepository : SoftDeletableEfRepository<User, long>
{
    public UserEfRepository(DatabaseContext context) : base(context) { }
}