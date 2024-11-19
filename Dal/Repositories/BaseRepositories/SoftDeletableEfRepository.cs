using Dal.DBContexts;
using Dal.Entities.BaseEntities;

namespace Dal.Repositories.BaseRepositories;

public class SoftDeletableEfRepository<TSoftDeletableEntity, TId> : BaseEfRepository<TSoftDeletableEntity>
    where TSoftDeletableEntity : SoftDeletableEntity<TId>
{
    public SoftDeletableEfRepository(DatabaseContext context) : base(context)
    { }
    
    public override async Task<TSoftDeletableEntity> DeleteAsync(TSoftDeletableEntity model)
    {
        model.MarkDeleted();
        await UpdateAsync(model);
        
        return model;
    }

    public override TSoftDeletableEntity Delete(TSoftDeletableEntity model)
    {
        model.MarkDeleted();
        Update(model);
        
        return model;
    }
}