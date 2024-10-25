using AspireApp1.WebUbam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspireApp1.WebUbam.Controllers;

[Authorize(Policy = "Admin")]
public class AgregarAlumnoController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string? _apiBaseUrl;

    public AgregarAlumnoController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient();
        _apiBaseUrl = configuration["API:BaseUrl"];
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new Alumno());
    }

    [HttpPost]
    public async Task<IActionResult> Agregar(Alumno alumno)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", alumno);
        }

        try
        {
            var apiUrl = $"{_apiBaseUrl}api/alumnos";
            var response = await _httpClient.PostAsJsonAsync(apiUrl, alumno);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadFromJsonAsync<CreateAlumnoResponse>();
                
                ViewBag.Usuario = responseContent.Usuario;
                ViewBag.Contrasena = responseContent.Contrasena;
                ViewBag.AlumnoCreado = true;

                return View("Index", alumno);
            }

            ViewBag.Error = "Error al guardar el alumno en la API.";
            return View("Index", alumno);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Ocurrió un error: {ex.Message}";
            return View("Index", alumno);
        }
    }
}