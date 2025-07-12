using Mggz.Shared.Entidades.Oficiales;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Mggz.AccessData.ContextDB;

public class DelabDbContext(DbContextOptions options) : DbContext(options)
{
    // DbSet properties for each entity
    public DbSet<Pais> Paises { get; set; } = null!;
    public DbSet<Estado> Estados { get; set; } = null!;
    public DbSet<Ciudad> Ciudades { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
