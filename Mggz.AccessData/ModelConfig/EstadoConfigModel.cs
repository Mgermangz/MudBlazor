using Mggz.Shared.Entidades.Oficiales;
using Microsoft.EntityFrameworkCore;

namespace Mggz.AccessData.ModelConfig;

public class EstadoConfigModel : IEntityTypeConfiguration<Estado>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estados", "Oficiales");
        builder.HasKey(e => e.EstadoId);
        builder.Property(e => e.EstadoId).ValueGeneratedOnAdd();
        builder.Property(e => e.Nombre)
               .IsRequired()
               .HasMaxLength(100);
        builder.HasIndex(e => e.Nombre).IsUnique();
        builder.Property(e => e.PaisId)
               .IsRequired();
        builder.HasOne(e => e.Pais);

        // Configuración de relaciones, si es necesario
        // Ejemplo: builder.HasMany(e => e.OtrosEntidades).WithOne().HasForeignKey(e => e.EstadoId);
    }
}