namespace AspireApp1.Web.Models;

public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> Login(UserLogin user)
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5561/api/auth/login", user);

        if (response.IsSuccessStatusCode)
        {
            // Aquí podrías guardar el token de autenticación si es necesario
            return true;
        }
        else
        {
            return false;
        }
    }
}