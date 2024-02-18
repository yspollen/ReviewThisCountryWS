using Microsoft.AspNetCore.Mvc;
using ReviewThisCountryWS.Models;
using ReviewThisCountryWS.Data;
using Microsoft.EntityFrameworkCore;

namespace ReviewThisCountryWS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ILogger<CountriesController> _logger;
    private readonly DBContext _context;

    public CountriesController(DBContext context, ILogger<CountriesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet(Name = "GetCountries")]
    public async Task<ActionResult<IEnumerable<Country>>> Get()
    {
        return await _context.Countries.ToListAsync();
    }
}

