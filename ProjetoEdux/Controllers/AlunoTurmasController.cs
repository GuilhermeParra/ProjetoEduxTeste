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
    public class AlunoTurmasController : ControllerBase
    {
        private readonly ProjetoSenaiiContext _context;

        public AlunoTurmasController(ProjetoSenaiiContext context)
        {
            _context = context;
        }

        // GET: api/AlunoTurmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoTurma>>> GetAlunoTurma()
        {
            return await _context.AlunoTurma.ToListAsync();
        }

        // GET: api/AlunoTurmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoTurma>> GetAlunoTurma(Guid id)
        {
            var alunoTurma = await _context.AlunoTurma.FindAsync(id);

            if (alunoTurma == null)
            {
                return NotFound();
            }

            return alunoTurma;
        }

        // PUT: api/AlunoTurmas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlunoTurma(Guid id, AlunoTurma alunoTurma)
        {
            if (id != alunoTurma.IdAlunoTurma)
            {
                return BadRequest();
            }

            _context.Entry(alunoTurma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoTurmaExists(id))
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

        // POST: api/AlunoTurmas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlunoTurma>> PostAlunoTurma(AlunoTurma alunoTurma)
        {
            _context.AlunoTurma.Add(alunoTurma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlunoTurma", new { id = alunoTurma.IdAlunoTurma }, alunoTurma);
        }

        // DELETE: api/AlunoTurmas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlunoTurma>> DeleteAlunoTurma(Guid id)
        {
            var alunoTurma = await _context.AlunoTurma.FindAsync(id);
            if (alunoTurma == null)
            {
                return NotFound();
            }

            _context.AlunoTurma.Remove(alunoTurma);
            await _context.SaveChangesAsync();

            return alunoTurma;
        }

        private bool AlunoTurmaExists(Guid id)
        {
            return _context.AlunoTurma.Any(e => e.IdAlunoTurma == id);
        }
    }
}
