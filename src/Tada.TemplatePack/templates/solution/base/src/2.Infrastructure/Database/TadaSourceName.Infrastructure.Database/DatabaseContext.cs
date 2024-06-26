using Microsoft.EntityFrameworkCore;

namespace TadaSourceName.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    // <!-- tada injection token -->
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
