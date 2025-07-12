using Mggz.Shared.Enums;

namespace Mggz.Shared.Entidades.Negocio;

public class Gerente
{
    public int GerenteId { get; set; }
    public string Nombres { get; set; } = null!;
    public string APaterno { get; set; } = null!;
    public string AMaterno { get; set; } = null!;
    public string UrlFoto { get; set; } = null!;
    public string RFC { get; set; } = null!;
    public string? Celular { get; set; }
    public string Direccion { get; set; } = null!;
    public string EmailUsuario { get; set; } = null!;
    public int EmpresaId { get; set; }
    public Empresa? EmpresaRow { get; set; }
    public eTipoUsuario TipoUsuario { get; set; }    
}
