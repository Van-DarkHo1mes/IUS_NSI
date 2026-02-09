using AngularWithAsp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWithAsp.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LPUController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public LPUController(ApplicationDbContext context)
    { 
      _context = context;
    }

    [HttpGet("getLpus")]
    public async Task<IActionResult> GetLpus()
    {
      var lpulist = await _context.Lpus.ToListAsync();

      if (lpulist == null || !lpulist.Any())
      {
        return NotFound();
      }

      return Ok(lpulist);
    }

    [HttpGet("getKS/{kodLPU}")]
    public async Task<IActionResult> GetKS(int kodLPU)
    {
      var ksList = await _context.Ks
          .FromSqlRaw("SELECT * FROM dbo.getKS({0})", kodLPU)
          .ToListAsync();

      if (ksList == null || !ksList.Any())
      {
        return NotFound();
      }

      return Ok(ksList);
    }
  }
}
