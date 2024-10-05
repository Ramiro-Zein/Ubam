namespace AspireApp1.Web.Models;

// User class
public class Usuario
{
    public Guid Id_Usuario { get; set; }
    public string Nombre_Usuario { get; set; }
    public string Apellido_Paterno_Usuario { get; set; }
    public string Apellido_Materno_Usuario { get; set; }
    public DateTime FechaNacimiento_Usuario { get; set; }
    public string Contrasena_Usuario { get; set; }
}