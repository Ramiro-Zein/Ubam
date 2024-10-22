using System.Text.Json;
using AspireApp1.WebUbam.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspireApp1.WebUbam.Controllers;

public class SolicitanteController : Controller
{
    private readonly HttpClient _httpClient;

    public SolicitanteController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var solicitantes = await GetSolicitantesAsync();
            if (solicitantes == null || !solicitantes.Any())
            {
                ViewBag.Error = "No se encontraron solicitantes.";
                return View(Enumerable.Empty<Solicitante>());
            }

            return View(solicitantes);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View(Enumerable.Empty<Solicitante>());
        }
    }

    private async Task<List<Solicitante>?> GetSolicitantesAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5561/api/solicitante");

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Solicitante>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        throw new Exception("Error al obtener solicitantes de la API.");
    }
}