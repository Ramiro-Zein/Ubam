using AspireApp1.WebUbam.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspireApp1.WebUbam.Controllers;

public class LoginController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    public LoginController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiUrl = configuration["API:BaseUrl"] + "api/login" ?? throw new ArgumentNullException(nameof(configuration), "La URL de la API no puede ser nula.");
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> IniciarSesion(Login login)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", login);
        }

        try
        {
            var response = await _httpClient.PostAsJsonAsync(_apiUrl, login);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Inicio de sesión exitoso");
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Credenciales inválidas. Inténtalo de nuevo.";
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Ocurrió un error al intentar iniciar sesión: {ex.Message}";
        }
        return View("Index", login);
    }
}