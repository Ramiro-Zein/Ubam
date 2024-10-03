namespace AspireApp1.Web.Models;

public class Solicitante
{
    public Guid Id_Solicitante { get; set; }
    public string Nombre_Solicitante { get; set; }
    public DateTime Fecha_Nacimiento_Solicitante { get; set; }
    
    public required ICollection<Pago> Pagos { get; set; }
}