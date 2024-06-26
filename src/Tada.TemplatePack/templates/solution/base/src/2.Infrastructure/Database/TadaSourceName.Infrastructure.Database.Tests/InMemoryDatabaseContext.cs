using Microsoft.EntityFrameworkCore;

namespace TadaSourceName.Infrastructure.Database.Tests;

public class InMemoryDatabaseContext : DatabaseContext
{
    public InMemoryDatabaseContext()
    {
        Seed();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    private void Seed()
    {
        // <!-- tada injection token -->
        this.SaveChanges();
    }
}
