using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.API.W.Models;

namespace Solution.API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCanchasController : ControllerBase
    {
        private readonly TaycoContext _context;

        public TipoCanchasController(TaycoContext context)
        {
            _context = context;
        }

        // GET: api/TipoCanchas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCancha>>> GetTipoCancha()
        {
            return await _context.TipoCancha.ToListAsync();
        }

        // GET: api/TipoCanchas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCancha>> GetTipoCancha(int id)
        {
            var tipoCancha = await _context.TipoCancha.FindAsync(id);

            if (tipoCancha == null)
            {
                return NotFound();
            }

            return tipoCancha;
        }

        // PUT: api/TipoCanchas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCancha(int id, TipoCancha tipoCancha)
        {
            if (id != tipoCancha.TipoCanchaId)
            {
                return BadRequest();
            }

            _context.Entry(tipoCancha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCanchaExists(id))
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

        // POST: api/TipoCanchas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoCancha>> PostTipoCancha(TipoCancha tipoCancha)
        {
            _context.TipoCancha.Add(tipoCancha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCancha", new { id = tipoCancha.TipoCanchaId }, tipoCancha);
        }

        // DELETE: api/TipoCanchas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoCancha>> DeleteTipoCancha(int id)
        {
            var tipoCancha = await _context.TipoCancha.FindAsync(id);
            if (tipoCancha == null)
            {
                return NotFound();
            }

            _context.TipoCancha.Remove(tipoCancha);
            await _context.SaveChangesAsync();

            return tipoCancha;
        }

        private bool TipoCanchaExists(int id)
        {
            return _context.TipoCancha.Any(e => e.TipoCanchaId == id);
        }
    }
}
