namespace AspireApp1.ApiService.Models
{
    public class Pago
    {
        public Guid Id_Pago { get; set; }
        public Guid Id_Solicitante { get; set; }
        public Double Monto_Pago { get; set; }
        public string Cuenta_Pago { get; set; }
        public string Sucursal_Pago { get; set; }
        public string Referencia_Pago { get; set; }
        public string Banco_Pago { get; set; }
        public string Concepto_Pago { get; set; }
        public DateTime Fecha_Limite_Pago { get; set; }

        // Propiedad de navegación
        public Solicitante Solicitante { get; set; } // Relación con Solicitante
    }
}
