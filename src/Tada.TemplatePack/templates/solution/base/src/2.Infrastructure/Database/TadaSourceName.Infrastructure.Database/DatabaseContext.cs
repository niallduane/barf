using System.Reflection;
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
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetAssembly(typeof(DatabaseContext))
                ?? throw new InvalidOperationException(
                    "Unable to get assembly for applying configurations from entities."
                );
        );
        base.OnModelCreating(modelBuilder);
    }
}
