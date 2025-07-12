using Mggz.Shared.Entidades.Admin;
using Mggz.Shared.Entidades.Negocio;
using Mggz.Shared.Entidades.Oficiales;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Mggz.AccessData.ContextDB;

public class DelabDbContext(DbContextOptions options) : IdentityDbContext<Usuario>(options)
{
    // DbSet properties for each entity
    public DbSet<Pais> Paises => Set<Pais>();
    public DbSet<Estado> Estados => Set<Estado>();
    public DbSet<Ciudad> Ciudades => Set<Ciudad>();
    public DbSet<SoftPlan> SoftPlans => Set<SoftPlan>();
    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Gerente> Gerentes => Set<Gerente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de las Tablas de Identity
        modelBuilder.Entity<Usuario>().ToTable("Usuarios", "Identity");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles", "Identity");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RolesClaims", "Identity");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsuariosClaims", "Identity");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsuariosLogins", "Identity");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsuariosRoles", "Identity");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsuariosTokens", "WebIdentity");

        // Configuración de las Tablas de Identidad Personalizadas
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
