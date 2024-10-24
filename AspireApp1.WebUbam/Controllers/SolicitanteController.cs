using System.Text.Json;
using AspireApp1.WebUbam.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspireApp1.WebUbam.Controllers;

public class SolicitanteController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    public SolicitanteController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiUrl = configuration["API:BaseUrl"] + "api/solicitante" ?? throw new ArgumentNullException(nameof(configuration), "La URL de la API no puede ser nula.");
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
        var response = await _httpClient.GetAsync(_apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Solicitante>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        throw new Exception("Error al obtener solicitantes de la API:: " + response.StatusCode);
    }
}