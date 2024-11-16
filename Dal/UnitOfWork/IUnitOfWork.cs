using Microsoft.EntityFrameworkCore.Storage;

namespace Dal.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IDbContextTransaction BeginTransaction();
    Task<int> SaveChangesAsync();
    int SaveChanges();
}