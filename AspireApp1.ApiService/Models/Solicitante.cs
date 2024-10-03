using System.Text.Json.Serialization;

namespace AspireApp1.ApiService.Models;

public class Solicitante
{
    public Guid Id_Solicitante { get; set; }
    public string Nombre_Solicitante { get; set; }
    public DateTime Fecha_Nacimiento_Solicitante { get; set; }

    // Relación con Pagos
    public ICollection<Pago> Pagos { get; set; }
}