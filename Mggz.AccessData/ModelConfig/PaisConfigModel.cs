using Mggz.Shared.Entidades.Oficiales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mggz.AccessData.ModelConfig;

public class PaisConfigModel : IEntityTypeConfiguration<Pais>
{
    /// <summary>
    /// // Define la configuración para la tabla de Paises.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("Paises", "oficiales");
        builder.Property(p => p.PaisId).ValueGeneratedOnAdd();
        builder.HasKey(p => p.PaisId);
        builder.Property(p => p.Nombre)
               .IsRequired()
               .HasMaxLength(100);
        builder.HasIndex(p => p.Nombre)
               .IsUnique();
        builder.Property(p => p.CodigoTelefono)
                .IsRequired()
                .HasMaxLength(10);
    }
}


