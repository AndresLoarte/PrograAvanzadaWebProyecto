using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.W.Models;

namespace API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEquipoController : ControllerBase
    {
        private readonly TaycoContext _context;

        public TipoEquipoController(TaycoContext context)
        {
            _context = context;
        }

        // GET: api/TipoEquipoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEquipo>>> GetTipoEquipo()
        {
            return await _context.TipoEquipo.ToListAsync();
        }

        // GET: api/TipoEquipoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEquipo>> GetTipoEquipo(int id)
        {
            var tipoEquipo = await _context.TipoEquipo.FindAsync(id);

            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return tipoEquipo;
        }

        // PUT: api/TipoEquipoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEquipo(int id, TipoEquipo tipoEquipo)
        {
            if (id != tipoEquipo.TipoEquipoId)
            {
                return BadRequest();
            }

            _context.Entry(tipoEquipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEquipoExists(id))
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

        // POST: api/TipoEquipoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoEquipo>> PostTipoEquipo(TipoEquipo tipoEquipo)
        {
            _context.TipoEquipo.Add(tipoEquipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoEquipo", new { id = tipoEquipo.TipoEquipoId }, tipoEquipo);
        }

        // DELETE: api/TipoEquipoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoEquipo>> DeleteTipoEquipo(int id)
        {
            var tipoEquipo = await _context.TipoEquipo.FindAsync(id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            _context.TipoEquipo.Remove(tipoEquipo);
            await _context.SaveChangesAsync();

            return tipoEquipo;
        }

        private bool TipoEquipoExists(int id)
        {
            return _context.TipoEquipo.Any(e => e.TipoEquipoId == id);
        }
    }
}
