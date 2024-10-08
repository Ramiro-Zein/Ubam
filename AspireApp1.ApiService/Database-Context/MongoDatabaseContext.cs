using AspireApp1.ApiService.Models;
using MongoDB.Driver;

namespace AspireApp1.ApiService.Database_Context;

public class MongoDatabaseContext : IDatabaseContext
{
    private readonly IMongoDatabase _database;

    private readonly IMongoCollection<Usuario> _usuarios;
    private readonly IMongoCollection<Solicitante> _solicitantes;
    private readonly IMongoCollection<Pago> _pagos;
    private readonly IMongoCollection<Alumno> _alumnos;

    public MongoDatabaseContext(IMongoClient mongoClient, IConfiguration configuration)
    {
        // Asegúrate de que la base de datos proviene de la configuración
        var databaseName = configuration["MongoDbSettings:Database"];
        _database = mongoClient.GetDatabase(databaseName);
        
        _usuarios = _database.GetCollection<Usuario>("Usuarios");
        _solicitantes = _database.GetCollection<Solicitante>("Solicitantes");
        _pagos = _database.GetCollection<Pago>("Pagos");
        _alumnos = _database.GetCollection<Alumno>("Alumnos");
    }

    public IQueryable<Usuario> Usuarios => _usuarios.AsQueryable();
    public IQueryable<Solicitante> Solicitantes => _solicitantes.AsQueryable();
    public IQueryable<Pago> Pagos => _pagos.AsQueryable();
    public IQueryable<Alumno> Alumnos => _alumnos.AsQueryable();
    public IQueryable<Usuario> Usuario { get; }
    public IQueryable<Solicitante> Solicitante { get; }
    public IQueryable<Pago> Pago { get; }
    public IQueryable<Alumno> Alumno { get; }
}