using System.Security.Claims;
using AspireApp1.ApiService.Database_Context;
using AspireApp1.ApiService.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller
{
    private readonly DatabaseContext _context;

    public LoginController(DatabaseContext context)
    {
        _context = context;
    }

    // POST: api/login
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] Login loginModel)
    {
        if (loginModel == null || string.IsNullOrEmpty(loginModel.Username) ||
            string.IsNullOrEmpty(loginModel.Password))
        {
            return BadRequest("Usuario o contraseña inválidos.");
        }

        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Nombre_Usuario == loginModel.Username);

        if (usuario == null)
        {
            return Unauthorized("Usuario no encontrado.");
        }
        
        if (usuario.Contrasena_Usuario != loginModel.Password)
        {
            return Unauthorized("Contraseña incorrecta.");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Nombre_Usuario),
            new Claim("FullName", $"{usuario.Nombre_Usuario} {usuario.Apellido_Paterno_Usuario}"),
            new Claim(ClaimTypes.Role, usuario.Rol_Usuario.ToString()),
            new Claim("UserId", usuario.Id_Usuario.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddHours(1)
            });

        return Ok("Inicio de sesión exitoso.");
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok("Cierre de sesión exitoso.");
    }

    [HttpGet("denied")]
    public IActionResult AccessDenied()
    {
        return Forbid();
    }
}