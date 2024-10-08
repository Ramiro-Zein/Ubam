using AspireApp1.ApiService.Models;

namespace AspireApp1.ApiService.Database_Context;

public interface IDatabaseContext
{
    IQueryable<Usuario> Usuario { get; }
    IQueryable<Solicitante> Solicitante { get; }
    IQueryable<Pago> Pago { get; }
    IQueryable<Alumno> Alumno { get; }

}
