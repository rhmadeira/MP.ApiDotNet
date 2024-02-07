using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

internal class DbApiDotNet : DbContext
{

    public DbApiDotNet(DbContextOptions<DbApiDotNet> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbApiDotNet).Assembly);
    }
}
