using Mggz.Shared.Entidades.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mggz.AccessData.ModelConfig;

public class SoftPlanConfigModel : IEntityTypeConfiguration<SoftPlan>
{
    public void Configure(EntityTypeBuilder<SoftPlan> builder)
    {
        builder.ToTable("SoftPlans", "Negocio");
        builder.HasKey(e => e.SoftPlanId);
        builder.Property(e => e.SoftPlanId).ValueGeneratedOnAdd();
        builder.Property(e => e.Nombre)
               .IsRequired()
               .HasMaxLength(100);
        builder.HasIndex(e => e.Nombre).IsUnique();
        builder.Property(e => e.Precio)
               .HasColumnType("decimal(18,2)")
               .IsRequired();
        builder.Property(e => e.Meses)
               .IsRequired();
        builder.Property(e => e.ClinicsCount)
               .IsRequired();        
    }
}
