using Microsoft.AspNetCore.Mvc;
using AspireApp1.WebUbam.Models;
using System.Text.Json;

namespace AspireApp1.WebUbam.Controllers;

public class AlumnoController : Controller
{
    private readonly HttpClient _httpClient;

    public AlumnoController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var alumnos = await GetAlumnosAsync();
            if (alumnos == null)
            {
                ViewBag.Error = "No se pudieron obtener los datos de los alumnos.";
                return View(Enumerable.Empty<Alumno>());
            }

            return View(alumnos);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View(Enumerable.Empty<Alumno>());
        }
    }

    private async Task<List<Alumno>?> GetAlumnosAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5561/api/alumnos");

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Alumno>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        throw new Exception("Error al obtener alumnos de la API.");
    }
}