using Mggz.Shared.Entidades.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mggz.AccessData.ModelConfig;

public class EmpresaConfigModel : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresas", "Negocio");
        builder.HasKey(e => e.EmpresaId);
        builder.Property(e => e.EmpresaId).ValueGeneratedOnAdd();
        builder.Property(e => e.RazonSocial)            
               .IsRequired()
               .HasMaxLength(150);
        builder.HasIndex(e => e.RFC)
               .IsUnique();
        builder.Property(e => e.PaisID)
               .IsRequired();
        builder.Property(e => e.FechaInicio)
               .IsRequired()
               .HasColumnType("datetime");
        builder.Property(e => e.FechaFinal)
               .IsRequired()
               .HasColumnType("datetime");
        builder.Property(e => e.UrlLogo)
                .HasMaxLength(250);

    }
}
