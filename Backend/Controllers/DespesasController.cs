using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerfinAPI.Data;
using GerfinAPI.Models;

namespace GerfinAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesasController : ControllerBase
    {
        private readonly GerfinDbContext _context;

        public DespesasController(GerfinDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Despesa>>> GetDespesas()
        {
            return await _context.Despesas.Include(d => d.Usuario).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Despesa>> GetDespesa(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            return despesa == null ? NotFound() : despesa;
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Despesa>>> GetDespesasPorUsuario(int usuarioId)
        {
            return await _context.Despesas.Where(d => d.UsuarioId == usuarioId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Despesa>> PostDespesa(Despesa despesa)
        {
            _context.Despesas.Add(despesa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDespesa), new { id = despesa.Id }, despesa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespesa(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa == null) return NotFound();

            _context.Despesas.Remove(despesa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
