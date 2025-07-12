using Mggz.Shared.Entidades.Oficiales;
using Microsoft.EntityFrameworkCore;

namespace Mggz.AccessData.ModelConfig;

public class CiudadConfigModel : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("Ciudades", "Oficiales");
        builder.HasKey(e => e.CiudadId);
        builder.Property(e => e.CiudadId).ValueGeneratedOnAdd();
        builder.Property(e => e.Nombre)
               .IsRequired()
               .HasMaxLength(100);
        builder.HasIndex(e => e.Nombre).IsUnique();
        builder.Property(e => e.EstadoId)
               .IsRequired();
        builder.HasOne(e => e.Estado);
        // Configuración de relaciones, si es necesario
        // Ejemplo: builder.HasMany(e => e.OtrosEntidades).WithOne().HasForeignKey(e => e.EstadoId);
    }
}