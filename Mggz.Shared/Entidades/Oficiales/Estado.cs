namespace Mggz.Shared.Entidades.Oficiales;

public class Estado
{
    public int EstadoId { get; set; }
    public string Nombre { get; set; } = null!;
    public int PaisId { get; set; }
    public Pais? Pais { get; set; }

}
