using Mggz.Shared.Entidades.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mggz.AccessData.ModelConfig;

public class GerenteConfigModel : IEntityTypeConfiguration<Gerente>
{
    public void Configure(EntityTypeBuilder<Gerente> builder)
    {
        builder.ToTable("Gerentes", "Negocio");
        builder.HasKey(e => e.GerenteId);
        builder.Property(e => e.GerenteId).ValueGeneratedOnAdd();
        builder.Property(e => e.Nombres)
               .IsRequired()
               .HasMaxLength(100);
        builder.Property(e => e.APaterno)
               .IsRequired()
               .HasMaxLength(100);
        builder.Property(e => e.AMaterno)
               .IsRequired()
               .HasMaxLength(100);
        builder.Property(e => e.EmailUsuario)
               .IsRequired()
               .HasMaxLength(150);
        builder.Property(e => e.Celular)
               .HasMaxLength(15);
        builder.Property(e => e.Direccion)
                .HasMaxLength(250);
        builder.HasIndex(e => e.RFC).IsUnique();
        builder.Property(e => e.RFC)
               .IsRequired()
               .HasMaxLength(13);
        builder.Property(e => e.UrlFoto)
                .HasMaxLength(250)
                .HasDefaultValue("http://localhost:5229/imagenes/NoImagen.png");
    }
}
