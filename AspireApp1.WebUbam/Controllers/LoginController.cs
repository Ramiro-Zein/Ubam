using AspireApp1.WebUbam.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspireApp1.WebUbam.Controllers;

public class LoginController : Controller
{
    private readonly HttpClient _httpClient;

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
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5561/api/login", login);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            
            Console.WriteLine("Inicio de sesión exitoso");
            
            ViewBag.Error = "Error al guardar el alumno en la API.";
            
            return View("Index", login);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Ocurrió un error: {ex.Message}";
            return View("Index", login);
        }
    }
}