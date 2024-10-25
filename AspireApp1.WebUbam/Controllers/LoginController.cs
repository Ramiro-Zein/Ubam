using System.Security.Claims;
using AspireApp1.WebUbam.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspireApp1.WebUbam.Controllers;

public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly ILogger<LoginController> _logger;

    public LoginController(IHttpClientFactory httpClientFactory, IConfiguration configuration,
        ILogger<LoginController> logger)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _logger = logger;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
    
        return View(new Login());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> IniciarSesion(Login login)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Modelo de login inválido.");
            return View("Index", login);
        }

        var client = _httpClientFactory.CreateClient();
        var baseUrl = _configuration["API:BaseUrl"].TrimEnd('/');
        var apiUrl = $"{baseUrl}/api/login/login";

        try
        {
            _logger.LogInformation("Enviando solicitud de login a la API: {ApiUrl}", apiUrl);
            var response = await client.PostAsJsonAsync(apiUrl, new
            {
                Username = login.Username,
                Password = login.Password
            });

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (loginResponse != null && loginResponse.Rol != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, login.Username),
                        new Claim(ClaimTypes.Role, loginResponse.Rol)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    _logger.LogInformation("Usuario {Username} autenticado exitosamente.", login.Username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _logger.LogWarning("Autenticación fallida para el usuario {Username}: {Mensaje}", login.Username,
                        loginResponse?.Mensaje);
                    ViewBag.Error = loginResponse?.Mensaje ?? "Credenciales inválidas. Inténtalo de nuevo.";
                    return View("Index", login);
                }
            }

            _logger.LogError("Respuesta no exitosa de la API. Status Code: {StatusCode}", response.StatusCode);
            ViewBag.Error = "Verifica tus datos";
            return View("Index", login);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Excepción al intentar comunicarse con la API.");
            ViewBag.Error = "Error, inténtalo más tarde.";
            return View("Index", login);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Login");
    }
}

public class LoginResponse
{
    public bool Exitoso { get; set; }
    public string? Mensaje { get; set; }
    public string? Rol { get; set; }
}