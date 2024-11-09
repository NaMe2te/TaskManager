using Dal.DBContexts;
using Dal.Entities;
using Dal.Repositories.BaseRepositories;

namespace Dal.Repositories;

public class CommentEfRepository : BaseEfRepository<Comment>
{
    public CommentEfRepository(DatabaseContext context) : base(context)
    { }
}