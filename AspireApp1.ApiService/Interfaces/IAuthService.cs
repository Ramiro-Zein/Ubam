using AspireApp1.ApiService.Models;

namespace AspireApp1.ApiService.Database_Context;

public interface IAuthService
{
    Task<string> Authenticate(Login login);
}