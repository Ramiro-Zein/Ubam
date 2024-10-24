using AspireApp1.WebUbam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AspireApp1.WebUbam.Controllers;

public class PagoController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    public PagoController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiUrl = configuration["API:BaseUrl"] + "api/pagos" ?? throw new ArgumentNullException(nameof(configuration), "La URL de la API no puede ser nula.");
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var pagos = await GetPagosAsync();
            if (pagos == null)
            {
                ViewBag.Error = "No se pudieron obtener los datos de los pagos.";
                return View(Enumerable.Empty<Pago>());
            }

            return View(pagos);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View(Enumerable.Empty<Pago>());
        }
    }

    private async Task<List<Pago>?> GetPagosAsync()
    {
        var response = await _httpClient.GetAsync(_apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Pago>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            throw new Exception("No se encontraron pagos.");

        throw new Exception("Error al obtener pagos de la API: " + response.StatusCode);
    }
}