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
    public class ObjetivoesController : ControllerBase
    {
        private readonly ProjetoSenaiiContext _context;

        public ObjetivoesController(ProjetoSenaiiContext context)
        {
            _context = context;
        }

        // GET: api/Objetivoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objetivo>>> GetObjetivo()
        {
            return await _context.Objetivo.ToListAsync();
        }

        // GET: api/Objetivoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objetivo>> GetObjetivo(Guid id)
        {
            var objetivo = await _context.Objetivo.FindAsync(id);

            if (objetivo == null)
            {
                return NotFound();
            }

            return objetivo;
        }

        // PUT: api/Objetivoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjetivo(Guid id, Objetivo objetivo)
        {
            if (id != objetivo.IdObjetivo)
            {
                return BadRequest();
            }

            _context.Entry(objetivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetivoExists(id))
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

        // POST: api/Objetivoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Objetivo>> PostObjetivo(Objetivo objetivo)
        {
            _context.Objetivo.Add(objetivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjetivo", new { id = objetivo.IdObjetivo }, objetivo);
        }

        // DELETE: api/Objetivoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Objetivo>> DeleteObjetivo(Guid id)
        {
            var objetivo = await _context.Objetivo.FindAsync(id);
            if (objetivo == null)
            {
                return NotFound();
            }

            _context.Objetivo.Remove(objetivo);
            await _context.SaveChangesAsync();

            return objetivo;
        }

        private bool ObjetivoExists(Guid id)
        {
            return _context.Objetivo.Any(e => e.IdObjetivo == id);
        }
    }
}
