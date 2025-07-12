using Mggz.Shared.Entidades.Admin;
using Mggz.Shared.Entidades.Oficiales;
using Mggz.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mggz.AccessData.ContextDB;

public class DatosSeedDb(DelabDbContext pContext, UserManager<Usuario> pUserManager)
{
    private readonly DelabDbContext _context = pContext;
    private readonly UserManager<Usuario> _userManager = pUserManager;

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CrearPaisesSeed();
        await CrearRolesSeed();
        await CrearUsuarioSistemas();
    }

    private async Task CrearUsuarioSistemas()
    {
        Usuario lUserSistemas = new Usuario();
        if (await _userManager.FindByNameAsync("sistemas") is not null) return;
        lUserSistemas = new()
        {
            APaterno = "",
            MPaterno = "",
            Nombres = "Sistemas",
            UserName = "sistemas",
            Email = "sistemasucay@outlook.com",
            EmailConfirmed = true,
            Activo = true,
            UrlFoto = "http://localhost:5229/imagenes/NoImagen.png",
            AccessFailedCount = 0,
            EmpresaId = 1,
        };
    }

    private async Task CrearRolesSeed()
    {
        if (_context.Roles.Any()) return;
        var roles = new List<string>
        {
            eTipoUsuario.Sistemas.ToString(),
            eTipoUsuario.Administrador.ToString(),
            eTipoUsuario.OficialCumplimiento.ToString(),
            eTipoUsuario.Supervisor.ToString(),
            eTipoUsuario.Operador.ToString(),
            eTipoUsuario.Auditor.ToString(),
            eTipoUsuario.Consultor.ToString(),
        };
        foreach (var role in roles)
        {
            if (!await _context.Roles.AnyAsync(r => r.Name == role))
            {
                await _context.Roles.AddAsync(new IdentityRole(role));
            }
        }
        await _context.SaveChangesAsync();
    }

    private async Task CrearPaisesSeed()
    {
        if (!_context.Paises.Any())
        {
            var paises = new List<Pais>
            {
                new Pais { Nombre = "México", CodigoTelefono = "+52" },
                new Pais { Nombre = "Estados Unidos", CodigoTelefono = "+1" },
                new Pais { Nombre = "Canadá", CodigoTelefono = "+15" },
                new Pais { Nombre = "Colombia", CodigoTelefono = "+57" }
            };
            _context.Paises.AddRange(paises);
            await _context.SaveChangesAsync();
        }
    }
}
