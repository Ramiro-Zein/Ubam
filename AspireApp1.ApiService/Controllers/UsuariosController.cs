using AspireApp1.ApiService.Database_Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly DatabaseContext _dbContext;
    public UsuariosController(DatabaseContext dbContext) { _dbContext = dbContext; }

    [HttpGet]
    public async Task<IActionResult> GetUsuarios() => Ok(await _dbContext.Usuarios.ToListAsync());
}