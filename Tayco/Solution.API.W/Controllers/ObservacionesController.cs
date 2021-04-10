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
    public class ObservacionesController : ControllerBase
    {
        private readonly TaycoContext _context;

        public ObservacionesController(TaycoContext context)
        {
            _context = context;
        }

        // GET: api/Observaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Observaciones>>> GetObservaciones()
        {
            return await _context.Observaciones.ToListAsync();
        }

        // GET: api/Observaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Observaciones>> GetObservaciones(int id)
        {
            var observaciones = await _context.Observaciones.FindAsync(id);

            if (observaciones == null)
            {
                return NotFound();
            }

            return observaciones;
        }

        // PUT: api/Observaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObservaciones(int id, Observaciones observaciones)
        {
            if (id != observaciones.ObservacionesId)
            {
                return BadRequest();
            }

            _context.Entry(observaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObservacionesExists(id))
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

        // POST: api/Observaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Observaciones>> PostObservaciones(Observaciones observaciones)
        {
            _context.Observaciones.Add(observaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObservaciones", new { id = observaciones.ObservacionesId }, observaciones);
        }

        // DELETE: api/Observaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Observaciones>> DeleteObservaciones(int id)
        {
            var observaciones = await _context.Observaciones.FindAsync(id);
            if (observaciones == null)
            {
                return NotFound();
            }

            _context.Observaciones.Remove(observaciones);
            await _context.SaveChangesAsync();

            return observaciones;
        }

        private bool ObservacionesExists(int id)
        {
            return _context.Observaciones.Any(e => e.ObservacionesId == id);
        }
    }
}
