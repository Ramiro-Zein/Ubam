using System.Text.Json.Serialization;

namespace AspireApp1.WebUbam.Models;
public class Pago
{
    public Guid Id_Pago { get; set; }
    public Double Monto_Pago { get; set; }
    public string Cuenta_Pago { get; set; }
    public string Sucursal_Pago { get; set; }
    public string Referencia_Pago { get; set; }
    public Banco Banco_Pago { get; set; }
    public string Concepto_Pago { get; set; }
    public DateTime Fecha_Limite_Pago { get; set; }
    
    public Guid SolicitanteId { get; set; }

    [JsonIgnore]
    public Solicitante Solicitante { get; set; }
    
    public enum Banco
    {
        BBVA,
        CitiBanamex
    }
}