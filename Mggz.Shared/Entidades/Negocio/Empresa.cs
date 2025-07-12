using Mggz.Shared.Entidades.Oficiales;

namespace Mggz.Shared.Entidades.Negocio;

public class Empresa
{
    public int EmpresaId { get; set; }
    public string RFC { get; set; } = null!;
    public int RazonSocial { get; set; }
    public int SoftPlanId { get; set; }
    public SoftPlan? SoftPlan { get; set; }
    public int PaisID { get; set; }
    public DateTime FechaInicio { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaFinal { get; set; }
    public string? UrlLogo { get; set; }    
    public Pais? PaisRow { get; set; }
}
