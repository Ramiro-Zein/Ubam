using AspireApp1.ApiService.Database_Context;
using AspireApp1.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddSqlServer<DatabaseContext>(builder.Configuration.GetConnectionString("CreateTables"));

// Database connection
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        )).ToArray();
    return forecast;
});

app.MapGet("/api/solicitantes", ([FromServices] DatabaseContext dbContext) =>
{
    return Results.Json(dbContext
        .Solicitantes
        .Include(s => s.Pagos)
    );
});

// Get Method
app.MapGet("/api/pagos", ([FromServices] DatabaseContext dbContext) => Results.Json(dbContext.Pagos));
app.MapGet("/api/usuarios", ([FromServices] DatabaseContext dbContext) => Results.Json(dbContext.Usuarios));
app.MapGet("/api/alumnos", ([FromServices] DatabaseContext dbContext) => Results.Json(dbContext.Alumnos));

// Post Method
app.MapPost("/api/alumnos", async ([FromServices] DatabaseContext dbContext, [FromBody] Alumno alumno) =>
{
    alumno.Id_Alumno = Guid.NewGuid();
    await dbContext.AddAsync(alumno);
    await dbContext.SaveChangesAsync();
    
    return Results.Ok(alumno);
});

// Put Method
app.MapPut("/api/alumnos/{id}", async ([FromServices] DatabaseContext dbContext, [FromBody] Alumno alumno, [FromRoute] Guid id) =>
{
    var alumno_actual = dbContext.Alumnos.Find(id);

    if (alumno_actual != null)
    {
        alumno_actual.Nombre_Alumno = alumno.Nombre_Alumno;
        alumno_actual.Apellido_Paterno_Alumno = alumno.Apellido_Paterno_Alumno;
        alumno_actual.Apellido_Materno_Alumno = alumno.Apellido_Materno_Alumno;
        alumno_actual.Fecha_Nacimiento_Alumno = alumno.Fecha_Nacimiento_Alumno;
        alumno_actual.Sexo_Alumno = alumno.Sexo_Alumno;
        alumno_actual.Carrera_Alumno = alumno.Carrera_Alumno;
        alumno_actual.Curp_Alumno = alumno.Curp_Alumno;
        alumno_actual.Bachillerato_Alumno = alumno.Bachillerato_Alumno;
        alumno_actual.Estado_Alumno = alumno.Estado_Alumno;
        
        await dbContext.SaveChangesAsync();
        return Results.Ok(alumno_actual);
    }
    
    return Results.NotFound();
});

// Delete Method
app.MapDelete("/api/alumnos/{id}", async ([FromServices] DatabaseContext dbContext, [FromRoute] Guid id) =>
{
    var alumno_actual = dbContext.Alumnos.Find(id);

    if (alumno_actual != null)
    {
        dbContext.Remove(alumno_actual);
        await dbContext.SaveChangesAsync();
        return Results.Ok(alumno_actual);
    }
    
    return Results.NotFound();
});

app.MapDefaultEndpoints();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
