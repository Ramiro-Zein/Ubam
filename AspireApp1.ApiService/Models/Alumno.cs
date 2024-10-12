namespace AspireApp1.ApiService.Models;

public class Alumno
{
    public Guid Id_Alumno { get; set; }
    public string Nombre_Alumno { get; set; }
    public string Apellido_Paterno_Alumno { get; set; }
    public string Apellido_Materno_Alumno { get; set; }
    public DateTime Fecha_Nacimiento_Alumno { get; set; }
    public Sexo Sexo_Alumno { get; set; }
    public String Carrera_Alumno { get; set; }
    
    public string Curp_Alumno { get; set; }
    public string Bachillerato_Alumno { get; set; }
    public string Estado_Alumno { get; set; }
    public enum Sexo
    {
        Masculino,
        Femenino
    }
    
}