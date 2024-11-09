using Microsoft.EntityFrameworkCore;

namespace Dal.DBContexts;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}