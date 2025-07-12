namespace Mggz.Shared.Entidades.Oficiales;

public class Ciudad
{
    public int CiudadId { get; set; }
    public string Nombre { get; set; } = null!;
    public int EstadoId { get; set; }
    public Estado? Estado { get; set; }
}
