using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEdux.Contexts;
using ProjetoEdux.Domains;

namespace ProjetoEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidasController : ControllerBase
    {
        private readonly ProjetoSenaiiContext _context;

        public CurtidasController(ProjetoSenaiiContext context)
        {
            _context = context;
        }

        // GET: api/Curtidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curtida>>> GetCurtida()
        {
            return await _context.Curtida.ToListAsync();
        }

        // GET: api/Curtidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curtida>> GetCurtida(Guid id)
        {
            var curtida = await _context.Curtida.FindAsync(id);

            if (curtida == null)
            {
                return NotFound();
            }

            return curtida;
        }

        // PUT: api/Curtidas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurtida(Guid id, Curtida curtida)
        {
            if (id != curtida.IdCurtida)
            {
                return BadRequest();
            }

            _context.Entry(curtida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurtidaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Curtidas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Curtida>> PostCurtida(Curtida curtida)
        {
            _context.Curtida.Add(curtida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurtida", new { id = curtida.IdCurtida }, curtida);
        }

        // DELETE: api/Curtidas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Curtida>> DeleteCurtida(Guid id)
        {
            var curtida = await _context.Curtida.FindAsync(id);
            if (curtida == null)
            {
                return NotFound();
            }

            _context.Curtida.Remove(curtida);
            await _context.SaveChangesAsync();

            return curtida;
        }

        private bool CurtidaExists(Guid id)
        {
            return _context.Curtida.Any(e => e.IdCurtida == id);
        }
    }
}
