
using AspireApp1.ApiService.Models;

namespace AspireApp1.ApiService;

public interface IDataService
{
    Task<IEnumerable<Alumno>> GetAlumnosAsync();
    Task<Models.Alumno> GetAlumnoAsync(Guid id);
    Task AddAlumnoAsync(Alumno alumno);
    Task UpdateAlumnoAsync(Alumno alumno);
    Task DeleteAlumnoAsync(Guid id);
}
