namespace AspireApp1.ApiService.Models;

public class LoginRequest
{
    public string Nombre_Usuario { get; set; }
    public string Contrasena_Usuario { get; set; }
}

public class LoginResponse
{
    public bool Exitoso { get; set; }
    public string? Mensaje { get; set; }
    public string? Rol { get; set; }
}
