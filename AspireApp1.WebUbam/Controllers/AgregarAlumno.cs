using AspireApp1.WebUbam.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspireApp1.WebUbam.Controllers;

public class AgregarAlumnoController : Controller
{
    private readonly HttpClient _httpClient;

    public AgregarAlumnoController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
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
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5561/api/alumnos", alumno);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AgregarAlumno");
            }
            else
            {
                ViewBag.Error = "Error al guardar el alumno en la API.";
                return View("Index", alumno);
            }
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Ocurrió un error: {ex.Message}";
            return View("Index", alumno);
        }
    }
}