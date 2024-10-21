using System.Text.Json;
using AspireApp1.WebUbam.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspireApp1.WebUbam.Controllers;

public class SolicitanteController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly string _apiUrl;

    public SolicitanteController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _apiUrl = "http://localhost:5561/api/pagos";
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var solicitantes = await GetSolicitantesAsync();
            if (solicitantes == null)
            {
                ViewBag.Error = "No se pudieron obtener los datos de los solicitantes.";
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

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            throw new Exception("No se encontraron solicitantes.");

        throw new Exception("Error al obtener solicitantes de la API. Código de estado: " + response.StatusCode);
    }
}