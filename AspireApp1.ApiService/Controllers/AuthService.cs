using System.Security.Claims;
using AspireApp1.ApiService.Database_Context;
using AspireApp1.ApiService.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService.Controllers;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task LogoutAsync();
}

public class AuthService : IAuthService
{
    private readonly DatabaseContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(DatabaseContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var caseSensitiveCollation = "Latin1_General_CS_AS";
        
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => 
                // EF.Functions.Collate aplica una collation específica (caseSensitiveCollation) para la comparación
                EF.Functions.Collate(u.Nombre_Usuario, caseSensitiveCollation) == request.Username && 
                EF.Functions.Collate(u.Contrasena_Usuario, caseSensitiveCollation) == request.Password);
        
        if (usuario == null)
        {
            return new LoginResponse
            {
                Exitoso = false,
                Mensaje = "Usuario o contraseña incorrectos."
            };
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Nombre_Usuario),
            new Claim(ClaimTypes.Role, usuario.Rol_Usuario.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true
        };

        await _httpContextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return new LoginResponse
        {
            Exitoso = true,
            Rol = usuario.Rol_Usuario.ToString(),
            Mensaje = "Bienvenido"
        };
    }

    public async Task LogoutAsync()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}