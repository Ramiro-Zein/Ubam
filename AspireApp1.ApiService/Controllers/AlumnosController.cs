using AspireApp1.ApiService.Database_Context;
using AspireApp1.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController : ControllerBase
{
    private readonly DatabaseContext _dbContext;
    public AlumnosController(DatabaseContext dbContext) { _dbContext = dbContext; }

    // GET Method
    [HttpGet]
    public async Task<IActionResult> GetAlumnos() => Ok(await _dbContext.Alumnos.ToListAsync());

    // GET: api/alumnos/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAlumno(Guid id)
    {
        var alumno = await _dbContext.Alumnos.FindAsync(id);
        if (alumno == null)
        {
            return NotFound();
        }

        return Ok(alumno);
    }

    // Post Method
    [HttpPost]
    public async Task<IActionResult> CreateAlumno(Alumno alumno)
    {
        await _dbContext.Alumnos.AddAsync(alumno);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAlumno), new { id = alumno.Id_Alumno }, alumno);
    }

    // Put Method
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAlumno(Guid id, Alumno alumno)
    {
        var alumno_actual = await _dbContext.Alumnos.FindAsync(id);

        if (alumno_actual == null)
        {
            return NotFound();
        }

        alumno_actual.Nombre_Alumno = alumno.Nombre_Alumno;
        alumno_actual.Apellido_Paterno_Alumno = alumno.Apellido_Paterno_Alumno;
        alumno_actual.Apellido_Materno_Alumno = alumno.Apellido_Materno_Alumno;
        alumno_actual.Fecha_Nacimiento_Alumno = alumno.Fecha_Nacimiento_Alumno;
        alumno_actual.Sexo_Alumno = alumno.Sexo_Alumno;
        alumno_actual.Carrera_Alumno = alumno.Carrera_Alumno;
        alumno_actual.Curp_Alumno = alumno.Curp_Alumno;
        alumno_actual.Bachillerato_Alumno = alumno.Bachillerato_Alumno;
        alumno_actual.Estado_Alumno = alumno.Estado_Alumno;

        await _dbContext.SaveChangesAsync();
        return Ok(alumno_actual);
    }

    // Delete Method
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlumno(Guid id)
    {
        var alumno_actual = await _dbContext.Alumnos.FindAsync(id);

        if (alumno_actual == null)
        {
            return NotFound();
        }

        _dbContext.Alumnos.Remove(alumno_actual);
        await _dbContext.SaveChangesAsync();
        return Ok(alumno_actual);
    }
}