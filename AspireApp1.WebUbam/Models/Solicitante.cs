namespace AspireApp1.WebUbam.Models;

public class Solicitante
{
    public Guid Id_Solicitante { get; set; }
    public string Nombre_Solicitante { get; set; }
    public DateTime Fecha_Nacimiento_Solicitante { get; set; }
    public List<Pago> Pagos { get; set; } = new List<Pago>(); 
}