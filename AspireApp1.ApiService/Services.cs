using AspireApp1.ApiService.Database_Context;
using AspireApp1.ApiService.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace AspireApp1.ApiService;

public class MongoDataService : IDataService
{
    private readonly IMongoCollection<Alumno> _alumnosCollection;

    public MongoDataService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDB");
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("<nombre_base_datos>");

        _alumnosCollection = database.GetCollection<Alumno>("Alumnos");
    }

    public async Task<IEnumerable<Alumno>> GetAlumnosAsync()
    {
        return await _alumnosCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Alumno> GetAlumnoAsync(Guid id)
    {
        return await _alumnosCollection.Find(a => a.Id_Alumno == id).FirstOrDefaultAsync();
    }

    public async Task AddAlumnoAsync(Alumno alumno)
    {
        alumno.Id_Alumno = Guid.NewGuid();
        await _alumnosCollection.InsertOneAsync(alumno);
    }

    public async Task UpdateAlumnoAsync(Alumno alumno)
    {
        await _alumnosCollection.ReplaceOneAsync(a => a.Id_Alumno == alumno.Id_Alumno, alumno);
    }

    public async Task DeleteAlumnoAsync(Guid id)
    {
        await _alumnosCollection.DeleteOneAsync(a => a.Id_Alumno == id);
    }
    // Implementa otros métodos si es necesario
}

public class SQLDataService : IDataService
{
    private readonly DatabaseContext _context;

    public SQLDataService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Alumno>> GetAlumnosAsync()
    {
        return await _context.Alumnos.ToListAsync();
    }

    public async Task<Alumno> GetAlumnoAsync(Guid id)
    {
        return await _context.Alumnos.FindAsync(id);
    }

    public async Task AddAlumnoAsync(Alumno alumno)
    {
        alumno.Id_Alumno = Guid.NewGuid();
        await _context.Alumnos.AddAsync(alumno);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAlumnoAsync(Alumno alumno)
    {
        _context.Alumnos.Update(alumno);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAlumnoAsync(Guid id)
    {
        var alumno = await _context.Alumnos.FindAsync(id);
        if (alumno != null)
        {
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();
        }
    }
    // Implementa otros métodos si es necesario
}