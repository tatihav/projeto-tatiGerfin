using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerfinAPI.Data;
using GerfinAPI.Models;

namespace GerfinAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RendasController : ControllerBase
    {
        private readonly GerfinDbContext _context;

        public RendasController(GerfinDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Renda>>> GetRendas()
        {
            return await _context.Rendas.Include(r => r.Usuario).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Renda>> GetRenda(int id)
        {
            var renda = await _context.Rendas.FindAsync(id);
            return renda == null ? NotFound() : renda;
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Renda>>> GetRendasPorUsuario(int usuarioId)
        {
            return await _context.Rendas.Where(r => r.UsuarioId == usuarioId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Renda>> PostRenda(Renda renda)
        {
            _context.Rendas.Add(renda);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRenda), new { id = renda.Id }, renda);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRenda(int id)
        {
            var renda = await _context.Rendas.FindAsync(id);
            if (renda == null) return NotFound();

            _context.Rendas.Remove(renda);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

