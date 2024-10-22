using System.ComponentModel.DataAnnotations;

namespace AspireApp1.ApiService.Models;

// User class
public class Usuario
{
    [Key]
    public Guid Id_Usuario { get; set; }
    public string? Nombre_Usuario { get; set; }
    public string Apellido_Paterno_Usuario { get; set; }
    public string Apellido_Materno_Usuario { get; set; }
    public DateTime FechaNacimiento_Usuario { get; set; }
    public string? Contrasena_Usuario { get; set; }
    
    public Rol? Rol_Usuario { get; set; }
    
    public enum Rol
    {
        Admin,
        alumno,
        Docente
    }
    
}