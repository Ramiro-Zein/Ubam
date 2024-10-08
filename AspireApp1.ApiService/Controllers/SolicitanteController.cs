using AspireApp1.ApiService.Database_Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SolicitanteController : ControllerBase
{
    private readonly DatabaseContext _dbContext;
    public SolicitanteController(DatabaseContext dbContext) 
    { 
        _dbContext = dbContext; 
    }

    [HttpGet]
    public async Task<IActionResult> GetSolicitantes()
    {
        var solicitantes = await _dbContext
            .Solicitantes
            .Include(s => s.Pagos)
            .ToListAsync();

        return Ok(solicitantes);
    }
}