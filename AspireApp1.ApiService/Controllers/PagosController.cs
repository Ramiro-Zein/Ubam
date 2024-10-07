using AspireApp1.ApiService.Database_Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagosController : ControllerBase
{
    private readonly DatabaseContext _dbContext;
    public PagosController(DatabaseContext dbContext) { _dbContext = dbContext; }

    // GET: api/pagos
    [HttpGet]
    public async Task<IActionResult> GetPagos() => Ok(await _dbContext.Pagos.ToListAsync());
}